using System;
using BaseballCommander.Application.Teams.Models;

namespace BaseballCommander.Application.Leagues.Models
{
    public class LeagueModel
    {
        public LeagueModel()
        {
            Teams = new TeamModel[0];
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public TeamModel[] Teams { get; set; }
    }
}