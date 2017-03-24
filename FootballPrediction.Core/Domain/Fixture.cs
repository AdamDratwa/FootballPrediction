using System;
using FootballPrediction.Core.ApiResponses;

namespace FootballPrediction.Core.Domain
{
    public class Fixture : Entity
    {
        public DateTime Date { get; set; }
        public int Matchday { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public GameStatus Status { get; set; }
        public Result Result { get; set; }
    }
}
