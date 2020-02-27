using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleContacts.Common.Authorization;
using SimpleContacts.Entities.Entities;
using SimpleContacts.Infrastructure.APIResponce;
using SimpleContacts.Services.Abstractions;
using SimpleContacts.ViewModels;
using SimpleContacts.Web.Helpers;

namespace SimpleContacts.Web.Controllers
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        private readonly IAuthorizationService _authorizationService;

        public UsersController(
            IMapper mapper,
            IAccountManager accountManager,
            IAuthorizationService authorizationService)
        {
            _mapper = mapper;
            _accountManager = accountManager;
            _authorizationService = authorizationService;
        }
        
        [HttpGet("me")]
        [ProducesResponseType(200, Type = typeof(UserViewModel))]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await GetUserById(ClaimsPrincipalHelper.GetUserId(this.User));
            return user;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserViewModel))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (!(await _authorizationService.AuthorizeAsync(this.User, UserRoles.SuperAdmin)).Succeeded)
                return new ChallengeResult();

            var userVM = await GetUserViewModelHelper(id);
            if (userVM != null)
                return Ok(userVM);

            return NotFound(id);
        }

        [HttpGet("username/{userName}")]
        [ProducesResponseType(200, Type = typeof(UserViewModel))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _accountManager.GetUserByUserNameAsync(userName);

            if (!(await _authorizationService.AuthorizeAsync(this.User, UserRoles.SuperAdmin)).Succeeded)
                return new ChallengeResult();

            if (user == null)
                return NotFound(userName);

            return await GetUserById(user.Id);
        }

        [HttpGet("")]
        [Authorize(Authorization.Policies.RequireAdminRole)]
        [ProducesResponseType(200, Type = typeof(List<UserViewModel>))]
        public async Task<ActionResult<ResponseMessageResult<PagedList<User>>>> GetUsers(int page = -1, int pageSize = -1)
        {
            var usersAndRoles = await _accountManager.GetUsersAndRolesAsync(page, pageSize);

            var users = new List<UserViewModel>();

            foreach(var item in usersAndRoles)
            {
                var user = _mapper.Map<UserViewModel>(item.User);
                user.Roles = item.Roles;

                users.Add(user);
            }

            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Create(UserViewModel user)
        {
            return await _accountManager.CreateUserAsync(user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> Update(string id, UserViewModel user)
        {
            return await _accountManager.UpdateUserAsync(id, user);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BaseResponseMessageResult>> DeleteById(string id)
        {
            return await _accountManager.DeleteUserAsync(id);
        }

        private async Task<UserViewModel> GetUserViewModelHelper(string id)
        {
            var userAndRoles = await _accountManager.GetUserAndRolesAsync(id);
            if (userAndRoles == null)
                return null;

            var user = _mapper.Map<UserViewModel>(userAndRoles.Value.User);
            user.Roles = userAndRoles.Value.Roles;

            return user;
        }
    }
}
