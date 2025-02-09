using System.ComponentModel.DataAnnotations;
using Entities.Abstract;

namespace Entities.Dtos
{
    public record RegisterDto : IEntity
    {
        [Required(ErrorMessage = "UserName is required")]
        public String? UserName { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public String? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public String? Password { get; init; }
    }
}