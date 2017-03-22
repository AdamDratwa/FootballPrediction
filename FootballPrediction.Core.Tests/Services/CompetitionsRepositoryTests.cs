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
            var competitionsApiCaller = new ApiCaller<CompetitionsResponse>(httpProvider);
            var competitionsRepository = new CompetitionsRepository(competitionsApiCaller);
            var competitions = await competitionsRepository.GetCompetitions(2016);
            Assert.That(competitions, Is.Not.Null);
        }
    }
}
