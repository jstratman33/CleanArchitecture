using System;
using CleanArchitecture.Core.Enumerations;

namespace CleanArchitecture.Core.Entities
{
    public class ShoppingItem
    {
        public long Id { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public ShoppingItemType Type { get; set; }
    }
}
