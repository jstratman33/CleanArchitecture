namespace BaseballCommander.Domain.Entities
{
    public class PlayerAttribute
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double PotentialValue { get; set; }
        public Player Player { get; set; }
    }
}