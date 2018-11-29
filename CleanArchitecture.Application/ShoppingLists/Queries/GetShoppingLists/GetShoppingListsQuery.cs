using System.Linq;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.ShoppingLists.Models;

namespace CleanArchitecture.Application.ShoppingLists.Queries.GetShoppingLists
{
    public class GetShoppingListsQuery : IGetShoppingListsQuery
    {
        private readonly IShoppingListRepository _repository;

        public GetShoppingListsQuery(IShoppingListRepository repository)
        {
            _repository = repository;
        }

        public ShoppingListModel[] Execute()
        {
            var shoppingLists = _repository.GetAll().Select(x => new ShoppingListModel
            {
                Guid = x.Guid,
                Name = x.Name,
                Items = x.Items.Select(i => new ShoppingItemModel
                {
                    Guid = i.Guid,
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Type = i.Type
                }).ToArray()
            });

            return shoppingLists.ToArray();
        }
    }
}