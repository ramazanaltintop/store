using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        Task<IdentityRole> GetOneRole(string id);
        Task<RoleDtoForUpdate> GetOneRoleForUpdate(string id);
        Task<IdentityResult> CreateRole(RoleDtoForInsertion roleDto);
        Task<IdentityResult> DeleteOneRole(string id);
        Task Update(RoleDtoForUpdate roleDto);


        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityUser> GetOneUser(string userName);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
        Task Update(UserDtoForUpdate userDto);
    }
}