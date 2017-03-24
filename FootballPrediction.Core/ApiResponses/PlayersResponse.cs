using System.Collections.Generic;

namespace FootballPrediction.Core.ApiResponses
{
    public class PlayersResponse : ApiElement
    {
        public int Count { get; set; }
        public IEnumerable<PlayerResponse> Players { get; set; }
    }
}
