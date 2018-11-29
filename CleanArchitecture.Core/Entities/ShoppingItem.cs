using System;
using CleanArchitecture.Domain.Enumerations;

namespace CleanArchitecture.Domain.Entities
{
    public class ShoppingItem : IEntity
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
