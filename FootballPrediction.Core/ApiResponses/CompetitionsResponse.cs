using System.Collections.Generic;

namespace FootballPrediction.Core.ApiResponses
{
    public class CompetitionsResponse : ApiElement
    {
        public IEnumerable<CompetitionResponse> Competitions { get; set; }
    }
}
