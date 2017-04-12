using System.Web.Http;
using FootballPrediction.Core.Storage.Interfaces;

namespace FootballPrediction
{
    public static class InitializeCache
    {
        public static void Execute(HttpConfiguration configuration)
        {
            var competitionsStorage = (ICompetitionsStorage)configuration.DependencyResolver.GetService(typeof(ICompetitionsStorage));
            competitionsStorage.InvalidateCache().GetAwaiter().GetResult();
        }
    }
}