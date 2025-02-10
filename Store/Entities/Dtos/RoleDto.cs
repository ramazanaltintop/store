using System.ComponentModel.DataAnnotations;
using Entities.Abstract;

namespace Entities.Dtos
{
    public record RoleDto : IEntity
    {
        public String? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public String? Name { get; init; } = String.Empty;

        [Required(ErrorMessage = "NormalizedName is required")]
        public String? NormalizedName { get; init; } = String.Empty;
    }
}