using System;
using BaseballCommander.Application.Leagues.Models;
using BaseballCommander.Application.Rosters.Models;

namespace BaseballCommander.Application.Teams.Models
{
    public class TeamModel
    {
        public TeamModel()
        {
            Rosters = new RosterModel[0];
            TeamPermissions = new TeamPermissionModel[0];
        }

        public Guid Guid { get; set; }
        public LeagueModel League { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public RosterModel[] Rosters { get; set; }
        public TeamPermissionModel[] TeamPermissions { get; set; }
    }
}