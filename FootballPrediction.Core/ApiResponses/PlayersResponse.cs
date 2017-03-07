using System.Collections.Generic;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.ApiResponses
{
    public class PlayersResponse : ApiElement
    {
        public int Count { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
