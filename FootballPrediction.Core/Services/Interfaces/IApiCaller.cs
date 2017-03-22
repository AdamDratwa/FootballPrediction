using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;

namespace FootballPrediction.Core.Services.Interfaces
{
    public interface IApiCaller<T> where T : ApiElement
    {
        Task<T> Get(string query);

        Task<IEnumerable<T>> GetMany(string query);
    }
}
