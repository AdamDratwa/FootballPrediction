using System;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Mappers
{
    public static class FixtureMapper
    {
        public static Fixture Map(FixtureResponse response)
        {
            return new Fixture
            {
                AwayTeamName = response.AwayTeamName,
                Date = Convert.ToDateTime(response.Date),
                HomeTeamName = response.HomeTeamName,
                Matchday = response.Matchday,
                Result = response.Result,
                Status = (GameStatus) Enum.Parse(typeof(GameStatus), response.Status, true)
            };
        }
    }
}
