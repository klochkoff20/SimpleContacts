using System;
using System.Threading.Tasks;
using SimpleContacts.ViewModels;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Infrastructure.APIResponce;
using System.Collections.Generic;

namespace SimpleContacts.Services.Abstractions
{
    public interface IAccountManager
    {
        Task<ResponseMessageResult<string>> CreateUserAsync(UserViewModel user);
        Task<(User User, string[] Roles)?> GetUserAndRolesAsync(string id);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<List<(User User, string[] Roles)>> GetUsersAndRolesAsync(int page, int pageSize);
        Task<BaseResponseMessageResult> UpdateUserAsync(string id, UserViewModel user);
        Task<BaseResponseMessageResult> DeleteUserAsync(string id);
    }
}
