using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Storage.Interfaces;
using Swashbuckle.Swagger.Annotations;

namespace FootballPrediction.Controllers
{
    public class CompetitionsController : ApiController
    {
        private readonly ICompetitionsStorage _competitionsStorage;

        public CompetitionsController(ICompetitionsStorage competitionsStorage)
        {
            _competitionsStorage = competitionsStorage;
        }

        [SwaggerResponse(HttpStatusCode.OK, "Gets active competitions", typeof(IEnumerable<Competition>))]
        public IHttpActionResult Get()
        {
            var competitions = _competitionsStorage.GetCompetitions();
            return Ok(competitions);
        }
    }
}
