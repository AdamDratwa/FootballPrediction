namespace FootballPrediction.Core.ApiResponses
{
    public class FixtureResponse : ApiElement
    {
        public int CompetitionId { get; set; }
        public string Date { get; set; }
        public int Matchday { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Status { get; set; }
        public Result Result { get; set; }
    }
}
