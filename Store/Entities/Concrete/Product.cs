using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "ProductName is required")]
        public String? ProductName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}