namespace FootballPrediction.Core.Domain
{
    public class Player : ApiElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
        public string  DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string ContractUntil { get; set; }
        public string MarketValue { get; set; }
    }
}
