using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }          // Primary Key
        public int? CategoryId { get; set; }        // Foreign Key        
        public String? ProductName { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public String? Summary { get; set; } = String.Empty;
        public String? ImageUrl { get; set; }
        public Category? Category { get; set; }     // Navigation Property
        public bool ShowCase { get; set; }
    }
}