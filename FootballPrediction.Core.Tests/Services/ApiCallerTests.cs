using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Services;
using NUnit.Framework;

namespace FootballPrediction.Core.Tests.Services
{
    [TestFixture]
    public class ApiCallerTests
    {
        [Test]
        public async Task Get_ShouldGetTeamFromApi()
        {
            var httpProvider = new HttpProvider();
            var apiCaller = new ApiCaller<TeamResponse>(httpProvider);
            var teams = await apiCaller.Get("competitions/398/teams");
            Assert.That(teams, Is.Not.Null);
        }
    }
}
