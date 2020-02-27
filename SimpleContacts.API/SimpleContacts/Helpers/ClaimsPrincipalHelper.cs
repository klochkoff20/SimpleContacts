using System.Linq;
using System.Security.Claims;
using IdentityModel;

namespace SimpleContacts.Web.Helpers
{
    public static class ClaimsPrincipalHelper
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirst(JwtClaimTypes.Subject)?.Value?.Trim();
        }
        public static string[] GetRoles(ClaimsPrincipal identity)
        {
            return identity.Claims
               .Where(c => c.Type == JwtClaimTypes.Role)
               .Select(c => c.Value)
               .ToArray();
        }
    }
}
