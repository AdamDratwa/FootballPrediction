using System.Web.Http;

namespace FootballPrediction
{
    public class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                "Competitions",
                "Competitions/{action}",
                new {controller = "Competitions", action = "Get"});
        }
    }
}
