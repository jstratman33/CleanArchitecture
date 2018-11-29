using CleanArchitecture.Application.ShoppingLists.Models;

namespace CleanArchitecture.Application.ShoppingLists.Commands.CreateShoppingList
{
    public interface ICreateShoppingListCommand
    {
        void Execute(ShoppingListModel model);
    }
}