using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballPrediction.Core.ApiResponses;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Mappers;
using FootballPrediction.Core.Services.Interfaces;

namespace FootballPrediction.Core.Services
{
    public class CompetitionsRepository : ICompetitionsRepository
    {
        private readonly IApiCaller<CompetitionResponse> _competitionsApiCaller;

        public CompetitionsRepository(IApiCaller<CompetitionResponse> competitionsApiCaller)
        {
            _competitionsApiCaller = competitionsApiCaller;
        }
        public async Task<IEnumerable<Competition>> GetCompetitions(int seasonYear)
        {
            var query = $"competitions?season={seasonYear}";
            var responce = await _competitionsApiCaller.GetMany(query);
            return responce.Select(CompetitionMapper.Map);
        }
    }
}
