using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Services.Interfaces
{
    public interface ICompetitionsRepository
    {
        Task<IEnumerable<Competition>> GetCompetitions(int seasonYear);
    }
}
