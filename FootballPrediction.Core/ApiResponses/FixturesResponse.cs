using System.Collections.Generic;

namespace FootballPrediction.Core.ApiResponses
{
    public class FixturesResponse : ApiElement
    {
        public IEnumerable<FixtureResponse> Fixtures { get; set; }
    }
}
