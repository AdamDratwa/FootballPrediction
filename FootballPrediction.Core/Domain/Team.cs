namespace FootballPrediction.Core.Domain
{
    public class Team : ApiElement
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SquadMarketValue { get; set; }
        public string CrestUrl { get; set; }
    }
}
