using BaseballCommander.Application.Users.Models;

namespace BaseballCommander.Application.Teams.Models
{
    public class TeamPermissionModel
    {
        public TeamModel Team { get; set; }
        public UserModel User { get; set; }
        public string Role { get; set; }
        public int Permission { get; set; }
    }
}