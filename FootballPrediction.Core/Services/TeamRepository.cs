using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Mappers;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IApiCaller<TeamResponse> _teamApiCaller;
        private readonly IApiCaller<PlayersResponse> _playersApiCaller;
        private readonly IApiCaller<FixturesResponse> _fixturesResponse;

        public TeamRepository(
            IApiCaller<TeamResponse> teamApiCaller, 
            IApiCaller<PlayersResponse> playersApiCaller,
            IApiCaller<FixturesResponse> fixturesApiCaller)
        {
            _teamApiCaller = teamApiCaller;
            _playersApiCaller = playersApiCaller;
            _fixturesResponse = fixturesApiCaller;
        }
        public async Task<Team> GetTeam(int id)
        {
            var query = $"teams/{id}";
            var responce = await _teamApiCaller.Get(query);
            return new Team
            {     
                Id = responce.Id,           
                CrestUrl = responce.CrestUrl,
                Name = responce.Name,
                ShortName = responce.ShortName,
                SquadMarketValue = responce.SquadMarketValue,
                Players = await GetPlayers(responce),
                Fixtures = await GetFixtures(responce)
            };
        }

        private async Task<IEnumerable<Fixture>> GetFixtures(TeamResponse responce)
        {
            var fixtures = await _fixturesResponse.Get(responce._Links.Fixtures.Href);
            return fixtures.Fixtures.Select(FixtureMapper.Map);
        }

        private async Task<IEnumerable<Player>> GetPlayers(TeamResponse responce)
        {
            var playersResponse = await _playersApiCaller.Get(responce._Links.Players.Href);
            return playersResponse.Players.Select(PlayerMapper.Map);
        }
    }
}
