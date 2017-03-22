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
        private readonly IApiCaller<TeamResponse> _apiCaller;
        private readonly IApiCaller<PlayersResponse> _playersApiCaller;
        private readonly IApiCaller<FixturesResponse> _fixturesApiCaller;

        public TeamsRepository(
            IApiCaller<TeamResponse> apiCaller, 
            IApiCaller<PlayersResponse> playersApiCaller,
            IApiCaller<FixturesResponse> fixturesApiCaller)
        {
            _apiCaller = apiCaller;
            _playersApiCaller = playersApiCaller;
            _fixturesApiCaller = fixturesApiCaller;
        }

        public async Task<IEnumerable<Team>> GetTeams(int competitionsId)
        {
            var query = $"competitions/{competitionsId}/teams";
            var responce = await _apiCaller.GetMany(query);
            return await GetFullInfoAboutTeams(responce.Select(TeamMapper.Map));
        }

        public async Task<Team> GetTeam(int id)
        {
            var query = $"teams/{id}";
            var responce = await _apiCaller.Get(query);
            return new Team
            {
                Id = responce.Id,
                CrestUrl = responce.CrestUrl,
                Name = responce.Name,
                ShortName = responce.ShortName,
                SquadMarketValue = responce.SquadMarketValue,
                Players = await GetPlayers(responce.Id),
                Fixtures = await GetFixtures(responce)
            };
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
                    Players = await GetPlayers(team.Id)
                });
            }
            return listOfTeams;
        }

        private async Task<IEnumerable<Player>> GetPlayers(int teamId)
        {
            var playersResponse = await _playersApiCaller.Get($"teams/{teamId}/players");
            return playersResponse.Players.Select(PlayerMapper.Map);
        }

        private async Task<IEnumerable<Fixture>> GetFixtures(TeamResponse responce)
        {
            var fixtures = await _fixturesApiCaller.Get(responce._Links.Fixtures.Href);
            return fixtures.Fixtures.Select(FixtureMapper.Map);
        }
    }
}
