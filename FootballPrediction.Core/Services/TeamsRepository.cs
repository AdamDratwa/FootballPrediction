using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Mappers;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly IApiCaller<TeamsResponse> _apiCaller;
        private readonly IApiCaller<PlayersResponse> _playersApiCaller;

        public TeamsRepository(
            IApiCaller<TeamsResponse> apiCaller, 
            IApiCaller<PlayersResponse> playersApiCaller)
        {
            _apiCaller = apiCaller;
            _playersApiCaller = playersApiCaller;
        }

        public async Task<IEnumerable<Team>> GetTeams(int competitionsId)
        {
            var query = $"competitions/{competitionsId}/teams";
            var responce = await _apiCaller.Get(query);
            return await GetFullInfoAboutTeams(responce.Teams.Select(TeamMapper.Map));
        }

        private async Task<IEnumerable<Team>> GetFullInfoAboutTeams(IEnumerable<Team> teams)
        {
            var listOfTeams = new List<Team>();
            foreach (var team in teams)
            {
                listOfTeams.Add(new Team
                {
                    Id = team.Id,
                    CrestUrl = team.CrestUrl,
                    Name = team.Name,
                    ShortName = team.ShortName,
                    SquadMarketValue = team.SquadMarketValue,
                    Players = await GetPlayers(team)
                });
            }
            return listOfTeams;
        }

        private async Task<IEnumerable<Player>> GetPlayers(Team team)
        {
            var playersResponse = await _playersApiCaller.Get($"teams/{team.Id}/players");
            return playersResponse.Players.Select(PlayerMapper.Map);
        }
    }
}
