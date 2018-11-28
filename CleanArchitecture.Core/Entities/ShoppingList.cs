using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class ShoppingList : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ShoppingItem> Items { get; set; } = new HashSet<ShoppingItem>();
    }
}