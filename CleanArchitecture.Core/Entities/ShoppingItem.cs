using CleanArchitecture.Core.Enumerations;

namespace CleanArchitecture.Core.Entities
{
    public class ShoppingItem : BaseEntity
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public ShoppingItemType Type { get; set; }
    }
}
