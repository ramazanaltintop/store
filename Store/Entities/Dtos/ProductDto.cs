using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Dtos
{
    public record ProductDto : IEntity
    {
        public int ProductId { get; init; }
        public int? CategoryId { get; init; }
        
        [Required(ErrorMessage = "ProductName is required")]
        public String? ProductName { get; init; } = String.Empty;

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }
    }
}