using AutoMapper;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles =>
            _roleManager.Roles;

        public async Task<IdentityResult> CreateOneRole(RoleDtoForInsertion roleDto)
        {
            var role = _mapper.Map<IdentityRole>(roleDto);
            return await _roleManager.CreateAsync(role);
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<RoleDtoForUpdate> GetOneRoleForUpdate(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            var roleDto = _mapper.Map<RoleDtoForUpdate>(role);
            return roleDto;
        }
    }
}