using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Mappers;
using NUnit.Framework;

namespace FootballPrediction.Core.Tests.Services
{
    [TestFixture]
    public class MapperTests
    {
        [Test]
        public void Map_ShouldMapFromApiElementToEntity()
        {
            var teamResponse = new TeamResponse
            {
                CrestUrl = "hehe",
                Id = 1,
                SquadMarketValue = "200",
                ShortName = "Gwardia Koszalin",
                Name = "Gwardia KSG"
            };
            var mapper = new Mapper<TeamResponse, Team>();
            var team = mapper.Map(teamResponse);
            Assert.That(team, Is.Not.Null);
        }
    }
}
