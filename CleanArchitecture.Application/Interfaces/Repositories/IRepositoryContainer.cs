using System;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IRepositoryContainer : IDisposable
    {
        IShoppingItemRepository ShoppingItem { get; }
        IShoppingListRepository ShoppingList { get; }
        int SaveChanges();
    }
}