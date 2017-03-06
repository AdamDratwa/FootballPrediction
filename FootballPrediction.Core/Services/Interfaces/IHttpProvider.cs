using System.Net.Http;

namespace FootballPrediction.Core.Services.Interfaces
{
    public interface IHttpProvider
    {
        HttpClient GetClient();
    }
}
