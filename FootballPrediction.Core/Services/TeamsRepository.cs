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

        public TeamsRepository(IApiCaller<TeamsResponse> apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public async Task<IEnumerable<Team>> GetTeams(int competitionsId)
        {
            var query = $"competitions/{competitionsId}/teams";
            var responce = await _apiCaller.Get(query);
            return responce.Teams;
        }
    }
}
