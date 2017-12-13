using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace FootballPrediction.Core.Services
{
    public class ApiCaller<T> : IApiCaller<T> where T : ApiElement
    {
        private readonly IHttpProvider _httpProvider;

        public ApiCaller(IHttpProvider httpProvider)
        {
            _httpProvider = httpProvider;
        }

        public async Task<T> Get(string query)
        {
            T item;

            using (var client = _httpProvider.GetClient())
            {
                var content = await client.GetAsync(query);
                var stringContent = await content.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<T>(stringContent);
            }

            return item;
        }

        public async Task<IEnumerable<T>> GetMany(string query)
        {
            IEnumerable<T> item;

            using (var client = _httpProvider.GetClient())
            {
                var content = await client.GetAsync(query);
                var stringContent = await content.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<IEnumerable<T>>(stringContent);
            }

            return item;
        }
    }
}
