using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; } = String.Empty;
    }
}