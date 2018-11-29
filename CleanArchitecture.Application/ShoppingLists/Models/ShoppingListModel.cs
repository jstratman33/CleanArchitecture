using System;
using System.Collections.Generic;
using CleanArchitecture.Application.ShoppingItems.Models;

namespace CleanArchitecture.Application.ShoppingLists.Models
{
    public class ShoppingListModel
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public ICollection<ShoppingItemModel> Items { get; set; } = new HashSet<ShoppingItemModel>();
    }
}