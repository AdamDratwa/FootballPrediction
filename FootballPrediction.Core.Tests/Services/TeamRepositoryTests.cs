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
            var apiCaller = new ApiCaller<TeamResponse>(httpProvider);
            var teamRepository = new TeamRepository(apiCaller);
            var team = await teamRepository.GetTeam(66);
            Assert.That(team, Is.Not.Null);
        }
    }
}
