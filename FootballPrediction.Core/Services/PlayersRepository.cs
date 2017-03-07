using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly IApiCaller<PlayersResponse> _apiCaller;

        public PlayersRepository(IApiCaller<PlayersResponse> apiCaller)
        {
            _apiCaller = apiCaller;
        }
        public async Task<IEnumerable<Player>> GetPlayers(int teamId)
        {
            var query = $"teams/{teamId}/players";
            var players = await _apiCaller.Get(query);
            return players.Players;
        }
    }
}
