using Business.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthManager(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> Roles =>
            _roleManager.Roles;
    }
}