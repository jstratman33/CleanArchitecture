namespace BaseballCommander.Domain.Entities
{
    public class Roster
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public string RosterType { get; set; }
        public long PlayerId { get; set; }
        public Team Team { get; set; }
        public Player Player { get; set; }
    }
}