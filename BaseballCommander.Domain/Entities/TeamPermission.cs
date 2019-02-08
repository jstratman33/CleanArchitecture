namespace BaseballCommander.Domain.Entities
{
    public class TeamPermission
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }
        public int Permission { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
    }
}