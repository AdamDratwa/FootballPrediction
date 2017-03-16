namespace FootballPrediction.Core.ApiResponses
{
    public class LeaguePositionResponse : ApiElement
    {
        public int Position { get; set; }
        public string TeamName { get; set; }
        public int PlayedGames { get; set; }
        public int Points { get; set; }
        public int Goals { get; set; }
        public int GoalsAgainst { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public Stats Home { get; set; }
        public Stats Away { get; set; }
    }
}
