namespace FootballPrediction.Core.ApiResponses
{
    public class FixtureResponse : ApiElement
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public string Date { get; set; }
        public int Matchday { get; set; }
        public string HomeTeamName { get; set; }
        public int HomeTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public int AwayTeamId { get; set; }
        public Result Result { get; set; }
    }
}
