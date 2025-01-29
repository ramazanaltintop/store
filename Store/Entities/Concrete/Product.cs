using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }          // Primary Key
        public int? CategoryId { get; set; }        // Foreign Key        
        public String? ProductName { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public Category? Category { get; set; }     // Navigation Property
    }
}