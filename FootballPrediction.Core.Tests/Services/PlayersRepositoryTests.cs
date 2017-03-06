using System.Threading.Tasks;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Services;
using NUnit.Framework;

namespace FootballPrediction.Core.Tests.Services
{
    [TestFixture]
    public class PlayersRepositoryTests
    {
        [Test]
        public async Task GetPlayers_ShouldGetListOfPlayersByTeamId()
        {
            var httpProvider = new HttpProvider();
            var apiCaller = new ApiCaller<Player>(httpProvider);
            var playersRepository = new PlayersRepository(apiCaller);
            var players = await playersRepository.GetPlayers(66);
            Assert.That(players, Is.Not.Null);
        }
    }
}
