using System.Collections.Generic;

namespace FootballPrediction.Core.Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SquadMarketValue { get; set; }
        public string CrestUrl { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Fixture> Fixtures { get; set; }
    }
}
