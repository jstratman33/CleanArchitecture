using System;
using CleanArchitecture.Domain.Enumerations;

namespace CleanArchitecture.Application.ShoppingItems.Models
{
    public class ShoppingItemModel
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public ShoppingItemType Type { get; set; }
    }
}