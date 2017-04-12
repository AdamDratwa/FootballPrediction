using System.Collections.Generic;

namespace FootballPrediction.Core.Domain
{
    public class Competition : Entity
    {
        public string Caption { get; set; }
        public string League { get; set; }
        public string Year { get; set; }
        public int CurrentMatchDay { get; set; }
        public int NumberOfMatchDays { get; set; }
        public int NumberOfTeams { get; set; }
        public int NumberOfGames { get; set; }
        public string LastUpdated { get; set; }

        public IEnumerable<Team> Teams { get; set; }
        public LeagueTable LeagueTable { get; set; }
        public IEnumerable<Fixture> Fixtures { get; set; }
    }
}
