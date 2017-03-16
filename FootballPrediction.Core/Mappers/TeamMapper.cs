using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Mappers
{
    public static class TeamMapper
    {
        public static Team Map(TeamResponse responce)
        {
            return new Team
            {
                CrestUrl = responce.CrestUrl,
                Id = responce.Id,
                Name = responce.Name,
                ShortName = responce.ShortName,
                SquadMarketValue = responce.SquadMarketValue
            };
        }
    }
}
