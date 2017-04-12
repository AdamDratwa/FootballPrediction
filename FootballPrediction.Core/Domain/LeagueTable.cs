using System.Collections.Generic;

namespace FootballPrediction.Core.Domain
{
    public class LeagueTable
    {
        public IEnumerable<LeaguePosition> Positions { get; set; }
    }
}
