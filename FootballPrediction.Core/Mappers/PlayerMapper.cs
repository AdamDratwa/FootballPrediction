using System;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Mappers
{
    public static class PlayerMapper
    {
        public static Player Map(PlayerResponse playerResponse)
        {
            return new Player
            {
                ContractUntil = Convert.ToDateTime(playerResponse.ContractUntil),
                DateOfBirth = Convert.ToDateTime(playerResponse.DateOfBirth),
                JerseyNumber = playerResponse.JerseyNumber,
                MarketValue = playerResponse.MarketValue,
                Name = playerResponse.Name,
                Nationality = playerResponse.Nationality,
                Position = playerResponse.Position
            };
        }
    }
}
