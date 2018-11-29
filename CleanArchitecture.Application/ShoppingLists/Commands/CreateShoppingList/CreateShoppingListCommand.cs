using System;
using System.Linq;
using CleanArchitecture.Application.Interfaces.Repositories;
using CleanArchitecture.Application.ShoppingLists.Models;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ShoppingLists.Commands.CreateShoppingList
{
    public class CreateShoppingListCommand : ICreateShoppingListCommand
    {
        private readonly IShoppingListRepository _repository;
        private readonly IDatabaseService _databaseService;

        public CreateShoppingListCommand(
            IShoppingListRepository repository,
            IDatabaseService databaseService)
        {
            _repository = repository;
            _databaseService = databaseService;
        }

        public void Execute(ShoppingListModel model)
        {
            var shoppingList = new ShoppingList
            {
                Guid = Guid.NewGuid(),
                Name = model.Name,
                Items = model.Items.Select(x => new ShoppingItem
                {
                    Guid = Guid.NewGuid(),
                    Name = x.Name,
                    Quantity = x.Quantity,
                    Type = x.Type
                }).ToArray()
            };

            _repository.Create(shoppingList);
            _databaseService.SaveChanges();
        }
    }
}