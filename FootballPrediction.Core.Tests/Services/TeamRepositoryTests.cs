using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Services;
using NUnit.Framework;

namespace FootballPrediction.Core.Tests.Services
{
    [TestFixture]
    public class TeamRepositoryTests
    {
        [Test]
        public async Task Get_ShouldGetTeamById()
        {
            var httpProvider = new HttpProvider();
            var teamApiCaller = new ApiCaller<TeamResponse>(httpProvider);
            var playersTeamApiCaller = new ApiCaller<PlayersResponse>(httpProvider);
            var fixturesApiCaller = new ApiCaller<FixturesResponse>(httpProvider);
            var teamRepository = new TeamsRepository(teamApiCaller, playersTeamApiCaller, fixturesApiCaller);
            var team = await teamRepository.GetTeam(66);
            Assert.That(team, Is.Not.Null);
        }
    }
}
