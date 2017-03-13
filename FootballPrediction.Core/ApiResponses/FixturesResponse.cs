using System.Collections.Generic;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.ApiResponses
{
    public class FixturesResponse : ApiElement
    {
        public IEnumerable<Fixture> Fixtures { get; set; }
    }
}
