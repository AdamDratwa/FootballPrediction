using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Services;
using NUnit.Framework;

namespace FootballPrediction.Core.Tests.Services
{
    [TestFixture]
    public class CompetitionsRepositoryTests
    {
        [Test]
        public async Task Get_ShouldGetCompetitionsForSeason()
        {
            var httpProvider = new HttpProvider();
            var competitionsApiCaller = new ApiCaller<CompetitionResponse>(httpProvider);
            var teamsApiCaller = new ApiCaller<TeamsResponse>(httpProvider);
            var fixturesApiCaller = new ApiCaller<FixturesResponse>(httpProvider);
            var competitionsRepository = new CompetitionsRepository(competitionsApiCaller, fixturesApiCaller, teamsApiCaller);
            var competitions = await competitionsRepository.GetCompetitions(2016);
            Assert.That(competitions, Is.Not.Null);
        }
    }
}
