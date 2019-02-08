using System;
using System.Collections.Generic;

namespace BaseballCommander.Domain.Entities
{
    public class Player
    {
        public Player()
        {
            PlayerAttributes = new HashSet<PlayerAttribute>();
        }

        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Status { get; set; }
        public Team Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GeneralPosition { get; set; }
        public int Age { get; set; }
        public ICollection<PlayerAttribute> PlayerAttributes { get; }
    }
}