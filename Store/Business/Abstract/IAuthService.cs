using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        Task<RoleDtoForUpdate> GetOneRoleForUpdate(string id);
        Task<IdentityResult> DeleteOneRole(string id);
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task<IdentityUser> GetOneUser(string userName);
    }
}