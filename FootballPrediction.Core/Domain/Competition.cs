namespace FootballPrediction.Core.Domain
{
    public class Competition
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string League { get; set; }
        public string Year { get; set; }
        public int CurrentMatchDay { get; set; }
        public int NumberOfMatchDays { get; set; }
        public int NumberOfTeams { get; set; }
        public int NumberOfGames { get; set; }
        public string LastUpdated { get; set; }
    }
}
