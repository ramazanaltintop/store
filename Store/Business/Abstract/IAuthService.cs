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
        Task<IdentityUser> GetOneUser(string userName);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task Update(UserDtoForUpdate userDto);
    }
}