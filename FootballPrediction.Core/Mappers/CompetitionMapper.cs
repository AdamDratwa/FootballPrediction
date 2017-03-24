using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Mappers
{
    public static class CompetitionMapper
    {
        public static Competition Map(CompetitionResponse competitionResponse)
        {
            return new Competition
            {
                Id = competitionResponse.Id,
                Caption = competitionResponse.Caption,
                CurrentMatchDay = competitionResponse.CurrentMatchDay,
                LastUpdated = competitionResponse.LastUpdated,
                League = competitionResponse.League,
                NumberOfGames = competitionResponse.NumberOfGames,
                NumberOfMatchDays = competitionResponse.NumberOfMatchDays,
                NumberOfTeams = competitionResponse.NumberOfTeams,
                Year = competitionResponse.Year
            };
        }
    }
}
