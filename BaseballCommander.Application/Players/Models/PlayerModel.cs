using System;
using BaseballCommander.Application.Teams.Models;
using BaseballCommander.Domain.Enumerations;

namespace BaseballCommander.Application.Players.Models
{
    public class PlayerModel
    {
        public PlayerModel()
        {
            PlayerAttributes = new PlayerAttributeModel[0];
        }

        public Guid Guid { get; set; }
        public PlayerStatus Status { get; set; }
        public TeamModel Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GeneralPosition GeneralPosition { get; set; }
        public int Age { get; set; }
        public PlayerAttributeModel[] PlayerAttributes { get; set; }
    }
}