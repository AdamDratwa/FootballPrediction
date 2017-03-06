using System;
using System.Net.Http;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class HttpProvider : IHttpProvider
    {
        private const string ApiBaseAddress = "http://api.football-data.org/v1/";
        private const string ApiToken = "6c6a3fa94b5f42328db6a9d3569abbec";

        public HttpClient GetClient()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(ApiBaseAddress)};
            httpClient.DefaultRequestHeaders.Add("X-Auth-Token", ApiToken);
            return httpClient;
        }
    }
}
