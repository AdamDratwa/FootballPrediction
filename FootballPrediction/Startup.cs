using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FootballPrediction.Startup))]

namespace FootballPrediction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            // InitializeCache.Execute(configuration);
            RegisterSwagger.Execute(configuration);
            ConfigureAuth(app);
            app.UseWebApi(configuration);
            app.UseWelcomePage();
        }
    }
}
