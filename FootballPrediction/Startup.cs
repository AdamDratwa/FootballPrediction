﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FootballPrediction.Startup))]

namespace FootballPrediction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseWelcomePage();
        }
    }
}
