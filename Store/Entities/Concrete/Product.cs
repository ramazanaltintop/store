using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}