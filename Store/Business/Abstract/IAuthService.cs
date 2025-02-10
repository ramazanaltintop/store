using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        Task<IdentityResult> CreateOneRole(RoleDtoForInsertion roleDto);
        Task<RoleDtoForUpdate> GetOneRoleForUpdate(string id);
        IEnumerable<IdentityUser> GetAllUsers();
    }
}