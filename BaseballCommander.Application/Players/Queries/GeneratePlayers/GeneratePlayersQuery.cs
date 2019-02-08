using System;
using System.Collections.Generic;
using BaseballCommander.Application.Players.Models;
using BaseballCommander.Application.Players.Queries.GetRandomAge;
using BaseballCommander.Application.Players.Queries.GetRandomGeneralPosition;
using BaseballCommander.Application.Players.Queries.GetRandomPlayerNames;
using BaseballCommander.Application.Players.Queries.GetRandomPlayerStatus;
using BaseballCommander.Application.Repositories;

namespace BaseballCommander.Application.Players.Queries.GeneratePlayers
{
    public class GeneratePlayersQuery : IGeneratePlayersQuery
    {
        private readonly INameGeneratorSourceRepository _repository;

        public GeneratePlayersQuery(INameGeneratorSourceRepository repository)
        {
            _repository = repository;
        }

        public PlayerModel[] Execute(GeneratePlayersRequest request)
        {
            var playNamesQuery = new GetRandomPlayerNamesQuery(_repository);
            var playerStatusQuery = new GetRandomPlayerStatusQuery();
            var generalPositionQuery = new GetRandomGeneralPositionQuery();
            var ageQuery = new GetRandomAgeQuery();

            var playerNames = playNamesQuery.Execute(request.NumberOfPlayersToCreate);
            var players = new List<PlayerModel>();
            foreach (var name in playerNames)
            {
                var playerStatus = playerStatusQuery.Execute(request.Situation);
                var generalPosition = generalPositionQuery.Execute();
                var age = ageQuery.Execute(playerStatus);
                players.Add(new PlayerModel()
                {
                    Guid = Guid.NewGuid(),
                    Status = playerStatus,
                    FirstName = name.FirstName,
                    LastName = name.LastName,
                    GeneralPosition = generalPosition,
                    Age = age
                });
            }

            return players.ToArray();
        }
    }
}