using BaseballCommander.Application.Players.Models;
using BaseballCommander.Application.Teams.Models;

namespace BaseballCommander.Application.Rosters.Models
{
    public class RosterModel
    {
        public TeamModel Team { get; set; }
        public string RosterType { get; set; }
        public PlayerModel Player { get; set; }
    }
}