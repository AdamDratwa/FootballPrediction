using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Services;
using FootballPrediction.Core.Services.Interfaces;
using NUnit.Framework;

namespace FootballPrediction.Core.Tests.Services
{
    [TestFixture]
    public class TeamsRepositoryTests
    {
        private ITeamsRepository _teamsRepository;

        [SetUp]
        public void BeforeEach()
        {
            var httpProvider = new HttpProvider();
            var teamApiCaller = new ApiCaller<TeamResponse>(httpProvider);
            var teamsApiCaller = new ApiCaller<TeamsResponse>(httpProvider);
            var playersTeamApiCaller = new ApiCaller<PlayersResponse>(httpProvider);
            var fixturesApiCaller = new ApiCaller<FixturesResponse>(httpProvider);
            _teamsRepository = new TeamsRepository(teamApiCaller, teamsApiCaller, playersTeamApiCaller, fixturesApiCaller);
        }

        [Test]
        public async Task Get_ShouldGetTeamById()
        {
            
            var team = await _teamsRepository.GetTeam(66);
            Assert.That(team, Is.Not.Null);
        }

        [Test]
        public async Task GetMany_ShouldGetTeams()
        {
            var teams = await _teamsRepository.GetTeams(394);
            Assert.That(teams, Is.Not.Null);
        }
    }
}
