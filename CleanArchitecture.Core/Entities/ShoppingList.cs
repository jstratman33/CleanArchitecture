using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class ShoppingList
    {
        public long Id { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public ICollection<ShoppingItem> Items { get; set; } = new HashSet<ShoppingItem>();
    }
}