using System;
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
        private readonly IApiCaller<TeamResponse> _teamApiCaller;
        private readonly IApiCaller<TeamsResponse> _teamsApiCaller;
        private readonly IApiCaller<PlayersResponse> _playersApiCaller;
        private readonly IApiCaller<FixturesResponse> _fixturesApiCaller;

        public TeamsRepository(
            IApiCaller<TeamResponse> teamApiCaller, 
            IApiCaller<TeamsResponse> teamsApiCaller,
            IApiCaller<PlayersResponse> playersApiCaller,
            IApiCaller<FixturesResponse> fixturesApiCaller)
        {
            _teamApiCaller = teamApiCaller;
            _teamsApiCaller = teamsApiCaller;
            _playersApiCaller = playersApiCaller;
            _fixturesApiCaller = fixturesApiCaller;
        }

        public async Task<IEnumerable<Team>> GetTeams(int competitionsId)
        {
            var query = $"competitions/{competitionsId}/teams";
            var responce = await _teamsApiCaller.Get(query);
            return await GetFullInfoAboutTeams(responce.Teams);
        }

        public async Task<Team> GetTeam(int id)
        {
            var query = $"teams/{id}";
            var responce = await _teamApiCaller.Get(query);
            return TeamMapper.Map(responce);
        }

        private async Task<IEnumerable<Team>> GetFullInfoAboutTeams(IEnumerable<TeamResponse> teamsResponses)
        {
            var teams = new List<Team>();
            foreach (var teamResponse in teamsResponses)
            {
                var team = TeamMapper.Map(teamResponse);
                team.Players = await GetPlayers(teamResponse._Links.Players.Href);
                team.Fixtures = await GetFixtures(teamResponse._Links.Fixtures.Href);
                teams.Add(team);
            }
            return teams;
        }

        private async Task<IEnumerable<Player>> GetPlayers(string link)
        {
            var query = link.Split(new[] {"v1/"}, StringSplitOptions.None)[1];
            var playersResponse = await _playersApiCaller.Get(query);
            return playersResponse.Players.Select(PlayerMapper.Map);
        }

        private async Task<IEnumerable<Fixture>> GetFixtures(string link)
        {
            var query = link.Split(new[] { "v1/" }, StringSplitOptions.None)[1];
            var fixtures = await _fixturesApiCaller.Get(query);
            return fixtures.Fixtures.Select(FixtureMapper.Map);
        }
    }
}
