using System.Linq;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Mappers
{
    public static class LeagueTableMapper
    {
        public static LeagueTable Map(LeagueTableResponse leagueTableResponse)
        {
            return new LeagueTable
            {
                Positions = leagueTableResponse.Standing.Select(GetPositions)
            };
        }

        private static LeaguePosition GetPositions(LeaguePositionResponse leaguePositionResponse)
        {
            return new LeaguePosition
            {
                Position = leaguePositionResponse.Position,
                Away = leaguePositionResponse.Away,
                Draws = leaguePositionResponse.Draws,
                Goals = leaguePositionResponse.Goals,
                GoalsAgainst = leaguePositionResponse.GoalsAgainst,
                Home = leaguePositionResponse.Home,
                Loses = leaguePositionResponse.Loses,
                PlayedGames = leaguePositionResponse.PlayedGames,
                Points = leaguePositionResponse.Points,
                TeamName = leaguePositionResponse.TeamName,
                Wins = leaguePositionResponse.Wins
            };
        }
    }
}
