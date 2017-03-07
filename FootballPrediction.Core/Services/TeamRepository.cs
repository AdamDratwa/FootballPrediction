using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IApiCaller<TeamResponse> _apiCaller;

        public TeamRepository(IApiCaller<TeamResponse> apiCaller)
        {
            _apiCaller = apiCaller;
        }
        public async Task<Team> GetTeam(int id)
        {
            var query = $"teams/{id}";
            var responce = await _apiCaller.Get(query);
            return new Team
            {
                CrestUrl = responce.CrestUrl,
                Name = responce.Name,
                ShortName = responce.ShortName,
                SquadMarketValue = responce.SquadMarketValue
            };
        }
    }
}
