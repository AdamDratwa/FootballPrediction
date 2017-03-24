namespace FootballPrediction.Core.ApiResponses.LinkReponses
{
    public class CompetitionLinks : Links
    {
        public Link LeagueTable { get; set; }

        public Link Fixtures { get; set; }

        public Link Teams { get; set; }
    }
}
