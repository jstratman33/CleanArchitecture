namespace BaseballCommander.Application.Players.Models
{
    public class PlayerAttributeModel
    {
        public PlayerModel Player { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double PotentialValue { get; set; }
    }
}