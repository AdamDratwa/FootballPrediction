using System.Threading.Tasks;
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
            var apiCaller = new ApiCaller<Team>(httpProvider);
            var team = await apiCaller.GetSingle("teams/66");
            Assert.That(team, Is.Not.Null);
        }
    }
}
