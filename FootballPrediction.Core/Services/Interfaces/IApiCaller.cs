using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.Services.Interfaces
{
    public interface IApiCaller<T> where T : ApiElement
    {
        Task<IEnumerable<T>> Get(string query);

        Task<T> GetSingle(string query);
    }
}
