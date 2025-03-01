using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateRole(RoleDtoForInsertion roleDto);
        IEnumerable<IdentityRole> Roles { get; }
        Task<IdentityRole> GetOneRole(string id);
        Task<RoleDtoForUpdate> GetOneRoleForUpdate(string id);
        Task Update(RoleDtoForUpdate roleDto);
        Task<IdentityResult> DeleteOneRole(string id);
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityUser> GetOneUser(string userName);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
        Task Update(UserDtoForUpdate userDto);
    }
}