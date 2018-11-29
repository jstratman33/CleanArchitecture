using CleanArchitecture.Application.ShoppingLists.Models;

namespace CleanArchitecture.Application.ShoppingLists.Queries.GetShoppingLists
{
    public interface IGetShoppingListsQuery
    {
        ShoppingListModel[] Execute();
    }
}