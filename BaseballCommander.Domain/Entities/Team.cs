using System;
using System.Collections.Generic;

namespace BaseballCommander.Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Rosters = new HashSet<Roster>();
            TeamPermissions = new HashSet<TeamPermission>();
        }

        public long Id { get; set; }
        public Guid Guid { get; set; }
        public long LeagueId { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public League League { get; set; }
        public ICollection<Roster> Rosters { get; }
        public ICollection<TeamPermission> TeamPermissions { get; }
    }
}