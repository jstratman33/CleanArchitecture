using System;
using System.Collections.Generic;
using BaseballCommander.Application.Players.Models;
using BaseballCommander.Application.Repositories;

namespace BaseballCommander.Application.Players.Queries.GetRandomPlayerNames
{
    public class GetRandomPlayerNamesQuery : IGetRandomPlayerNamesQuery
    {
        private readonly INameGeneratorSourceRepository _repository;

        public GetRandomPlayerNamesQuery(INameGeneratorSourceRepository repository)
        {
            _repository = repository;
        }

        public PlayerName[] Execute(int count)
        {
            var rnd = new Random();
            var countOfNames = _repository.Count();
            var names = new List<PlayerName>();

            for (var i = 0; i < count; ++i)
            {
                var rndFirstName = rnd.Next(countOfNames);
                var rndLastName = rnd.Next(countOfNames);
                names.Add(new PlayerName()
                {
                    FirstName = _repository.GetRowByIndex(rndFirstName).FirstName,
                    LastName = _repository.GetRowByIndex(rndLastName).LastName
                });
            }

            return names.ToArray();
        }
    }
}