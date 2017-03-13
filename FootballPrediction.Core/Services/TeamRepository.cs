using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IApiCaller<TeamResponse> _teamApiCaller;
        private readonly IApiCaller<PlayersResponse> _playersApiCaller;

        public TeamRepository(
            IApiCaller<TeamResponse> teamApiCaller, 
            IApiCaller<PlayersResponse> playersApiCaller)
        {
            _teamApiCaller = teamApiCaller;
            _playersApiCaller = playersApiCaller;
        }
        public async Task<Team> GetTeam(int id)
        {
            var query = $"teams/{id}";
            var responce = await _teamApiCaller.Get(query);
            return new Team
            {     
                Id = responce.Id,           
                CrestUrl = responce.CrestUrl,
                Name = responce.Name,
                ShortName = responce.ShortName,
                SquadMarketValue = responce.SquadMarketValue,
                Players = await GetPlayers(responce)               
            };
        }

        private async Task<IEnumerable<Player>> GetPlayers(TeamResponse responce)
        {
            var playersResponse = await _playersApiCaller.Get(responce._Links.Players.Href);
            return playersResponse.Players;
        }
    }
}
