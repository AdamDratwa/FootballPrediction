using System.Collections.Generic;

namespace FootballPrediction.Core.ApiResponses
{
    public class TeamsResponse : ApiElement
    {
        public int Count { get; set; }
        public IEnumerable<TeamResponse> Teams { get; set; }
    }
}
