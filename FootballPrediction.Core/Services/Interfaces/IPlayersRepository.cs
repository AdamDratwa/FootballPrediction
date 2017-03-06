using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Services.Interfaces
{
    public interface IPlayersRepository
    {
        Task<IEnumerable<Player>> GetPlayers(int teamId);
    }
}
