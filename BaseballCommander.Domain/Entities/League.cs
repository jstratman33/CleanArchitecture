using System;
using System.Collections.Generic;

namespace BaseballCommander.Domain.Entities
{
    public class League
    {
        public League()
        {
            Teams = new HashSet<Team>();
        }

        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public ICollection<Team> Teams { get; }
    }
}