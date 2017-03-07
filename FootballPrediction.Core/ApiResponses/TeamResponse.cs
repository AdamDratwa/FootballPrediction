using FootballPrediction.Core.ApiResponses.LinkReponses;

namespace FootballPrediction.Core.ApiResponses
{
    public class TeamResponse : ApiElement
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SquadMarketValue { get; set; }
        public string CrestUrl { get; set; }
        public Links _Links { get; set; }
    }
}
