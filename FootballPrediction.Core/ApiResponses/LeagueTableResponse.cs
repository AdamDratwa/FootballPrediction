using System.Collections.Generic;

namespace FootballPrediction.Core.ApiResponses
{
    public class LeagueTableResponse : ApiElement
    {
        public IEnumerable<LeaguePositionResponse> Standing { get; set; }
    }
}
