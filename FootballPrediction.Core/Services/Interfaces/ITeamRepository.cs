using System.Threading.Tasks;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Services.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetTeam(int id);
    }
}
