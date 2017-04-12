using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Storage.Interfaces
{
    public interface ICompetitionsStorage
    {
        IEnumerable<Competition> GetCompetitions();
        Task InvalidateCache();
    }
}
