using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleContacts.DAL;
using SimpleContacts.ViewModels;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.Infrastructure.APIResponce;
using AutoMapper;
using SimpleContacts.DAL.Abstractions;

namespace SimpleContacts.Services.Implementations
{
    public class AccountManager : IAccountManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AccountManager(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ApplicationDbContext context,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
        }

        public async Task<ResponseMessageResult<string>> CreateUserAsync(UserViewModel user)
        {
            var response = new ResponseMessageResult<string>();

            user.Id = Guid.NewGuid().ToString();
            var newUser = _mapper.Map<User>(user);

            await _context.Users.AddAsync(newUser);
            await _unitOfWork.SaveChangesAsync();

            response.Content = user.Id;
            response.Message = $"User [{user.UserName}] Id: [{user.Id}] was successfully added!";

            return response;
        }

        public async Task<(User User, string[] Roles)?> GetUserAndRolesAsync(string id)
        {
            var response = new ResponseMessageResult<(User User, string[] Roles)?>();

            var user = await _context.Users
               .Include(u => u.Roles)
               .Where(u => u.Id == id)
               .SingleOrDefaultAsync();

            if (user == null)
                return null;

            var userRoleIds = user.Roles.Select(r => r.RoleId).ToList();

            var roles = await _context.Roles
                .Where(r => userRoleIds.Contains(r.Id))
                .Select(r => r.Name)
                .ToArrayAsync();

            return (user, roles);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return null;

            return user;
        }

        public async Task<List<(User User, string[] Roles)>> GetUsersAndRolesAsync(int page, int pageSize)
        {
            IQueryable<User> usersQuery = _context.Users
                .Include(u => u.Roles)
                .OrderBy(u => u.UserName);

            if (page != -1)
                usersQuery = usersQuery.Skip((page - 1) * pageSize);
            if (pageSize != -1)
                usersQuery = usersQuery.Take(pageSize);

            var users = await usersQuery.ToListAsync();

            var userRoleIds = users.SelectMany(u => u.Roles.Select(r => r.RoleId)).ToList();
            var roles = await _context.Roles
                .Where(r => userRoleIds.Contains(r.Id))
                .ToArrayAsync();

            var result = users
                .Select(u => (u, roles.Where(r => u.Roles.Select(ur => ur.RoleId).Contains(r.Id)).Select(r => r.Name).ToArray()))
                .ToList();

            return result;
        }

        public async Task<BaseResponseMessageResult> UpdateUserAsync(string id, UserViewModel user)
        {
            var response = new BaseResponseMessageResult();

            var oldUser = await _context.Users
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync();
            
            if (oldUser == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"User [{id}] was not found!");
                return response;
            }

            var updatedUser = _mapper.Map<User>(user);
            _context.Users.Update(updatedUser);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"User [{id}] was updated!";
            return response;
        }

        public async Task<BaseResponseMessageResult> DeleteUserAsync(string id)
        {
            var response = new BaseResponseMessageResult();

            var user = await _context.Users
               .Where(u => u.Id == id)
               .SingleOrDefaultAsync();

            if (user == null)
            {
                response.SetStatus(HttpStatusCode.NotFound, $"User [{id}] was not found!");
                return response;
            }

            _context.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();

            response.Message = $"User [{id}] was removed!";
            return response;
        }
    }
}
