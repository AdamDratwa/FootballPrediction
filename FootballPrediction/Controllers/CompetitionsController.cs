using System.Collections.Generic;
using System.Web.Http;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Storage.Interfaces;

namespace FootballPrediction.Controllers
{
    public class CompetitionsController : ApiController
    {
        private readonly ICompetitionsStorage _competitionsStorage;

        public CompetitionsController(ICompetitionsStorage competitionsStorage)
        {
            _competitionsStorage = competitionsStorage;
        }

        public IEnumerable<Competition> Get()
        {
            return _competitionsStorage.GetCompetitions();
        }
    }
}
