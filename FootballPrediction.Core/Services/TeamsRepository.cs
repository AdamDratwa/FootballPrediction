using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly IApiCaller<TeamsResponse> _apiCaller;
        private readonly IApiCaller<PlayersResponse> _playersApiCaller;

        public TeamsRepository(IApiCaller<TeamsResponse> apiCaller, IApiCaller<PlayersResponse> playersApiCaller)
        {
            _apiCaller = apiCaller;
            _playersApiCaller = playersApiCaller;
        }

        public async Task<IEnumerable<Team>> GetTeams(int competitionsId)
        {
            var query = $"competitions/{competitionsId}/teams";
            var responce = await _apiCaller.Get(query);
            return GetFullInfoAboutTeams(responce.Teams);
        }

        private IEnumerable<Team> GetFullInfoAboutTeams(IEnumerable<Team> teams)
        {
            foreach (var team in teams)
            {
                yield return new Team
                {
                    Id = team.Id,
                    CrestUrl = team.CrestUrl,
                    Name = team.Name,
                    ShortName = team.ShortName,
                    SquadMarketValue = team.SquadMarketValue,
                    Players = _playersApiCaller.Get($"teams/{team.Id}/players")
                };
            }
        }
    }
}
