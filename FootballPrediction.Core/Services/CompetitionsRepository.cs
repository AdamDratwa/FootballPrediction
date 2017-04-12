using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Extensions;
using FootballPrediction.Core.Mappers;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class CompetitionsRepository : ICompetitionsRepository
    {
        private readonly IApiCaller<CompetitionResponse> _competitionsApiCaller;
        private readonly IApiCaller<FixturesResponse> _fixturesApiCaller;
        private readonly IApiCaller<TeamsResponse> _teamsApiCaller;

        public CompetitionsRepository(
            IApiCaller<CompetitionResponse> competitionsApiCaller, 
            IApiCaller<FixturesResponse> fixturesApiCaller, 
            IApiCaller<TeamsResponse> teamsApiCaller)
        {
            _competitionsApiCaller = competitionsApiCaller;
            _fixturesApiCaller = fixturesApiCaller;
            _teamsApiCaller = teamsApiCaller;
        }
        public async Task<IEnumerable<Competition>> GetCompetitions(int seasonYear)
        {
            var competitions = new List<Competition>();
            var query = $"competitions?season={seasonYear}";
            var responce = await _competitionsApiCaller.GetMany(query);
            foreach (var item in responce)
            {
                var competiton = CompetitionMapper.Map(item);
                competiton.Teams = await GetTeams(item._Links.Teams.Href.Query());
                competiton.Fixtures = await GetFixtures(item._Links.Fixtures.Href.Query());
                competitions.Add(competiton);
            }
            return competitions;
        }

        private async Task<IEnumerable<Fixture>> GetFixtures(string query)
        {
            var fixturesResponse = await _fixturesApiCaller.Get(query);
            return fixturesResponse.Fixtures.Select(FixtureMapper.Map);
        }

        private async Task<IEnumerable<Team>> GetTeams(string query)
        {
            var teamsResponse = await _teamsApiCaller.Get(query);
            return teamsResponse.Teams.Select(TeamMapper.Map);
        }
    }
}
