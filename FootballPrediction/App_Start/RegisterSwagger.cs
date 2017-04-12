using System.Web.Http;
using Swashbuckle.Application;

namespace FootballPrediction
{
    public static class RegisterSwagger
    {
        public static void Execute(HttpConfiguration configuration)
        {
            configuration.EnableSwagger(Configure).EnableSwaggerUi(ConfigureUi);
        }

        private static void ConfigureUi(SwaggerUiConfig config)
        {
            config.DocExpansion(DocExpansion.List);
            config.DisableValidator(); ;
        }

        private static void Configure(SwaggerDocsConfig config)
        {
            config.SingleApiVersion("V1", "FootballPrediction");
        }
    }
}