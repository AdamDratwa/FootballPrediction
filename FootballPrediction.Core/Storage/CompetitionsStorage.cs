using System.Collections.Generic;
using System.Threading.Tasks;
using FootballPrediction.Core.Domain;
using FootballPrediction.Core.Properties;
using FootballPrediction.Core.Services.Interfaces;
using FootballPrediction.Core.Storage.Interfaces;

namespace FootballPrediction.Core.Storage
{
    public class CompetitionsStorage : ICompetitionsStorage
    {
        private readonly ICompetitionsRepository _competitionsRepository;

        private IEnumerable<Competition> _competitions;

        public CompetitionsStorage(ICompetitionsRepository competitionsRepository)
        {
            _competitionsRepository = competitionsRepository;
        }

        public IEnumerable<Competition> GetCompetitions()
        {
            return _competitions;
        }

        public async Task InvalidateCache()
        {
            var seasonYear = Settings.Default.Season;
            _competitions = await _competitionsRepository.GetCompetitions(seasonYear);
        }
    }
}
