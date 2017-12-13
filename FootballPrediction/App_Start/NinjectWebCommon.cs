using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Services;
using FootballPrediction.Core.Services.Interfaces;
using FootballPrediction.Core.Storage;
using FootballPrediction.Core.Storage.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FootballPrediction.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FootballPrediction.App_Start.NinjectWebCommon), "Stop")]

namespace FootballPrediction.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            { 
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICompetitionsStorage>().To<CompetitionsStorage>();
            kernel.Bind<IApiCaller<CompetitionResponse>>().To<ApiCaller<CompetitionResponse>>();
            kernel.Bind<IApiCaller<TeamsResponse>>().To<ApiCaller<TeamsResponse>>();
            kernel.Bind<IApiCaller<FixturesResponse>>().To<ApiCaller<FixturesResponse>>();
            kernel.Bind<IApiCaller<CompetitionResponse>>().To<ApiCaller<CompetitionResponse>>();
            kernel.Bind<IHttpProvider>().To<HttpProvider>();
            kernel.Bind<ICompetitionsRepository>().To<CompetitionsRepository>();
            kernel.Bind<IPlayersRepository>().To<PlayersRepository>();
            kernel.Bind<ITeamsRepository>().To<TeamsRepository>();
        }        
    }
}
