using FootballPrediction.Core.ApiResponses;

namespace FootballPrediction.Core.Domain
{
    public class Fixture : Entity
    {
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
