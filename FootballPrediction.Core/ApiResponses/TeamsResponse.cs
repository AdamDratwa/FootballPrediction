﻿using System.Collections.Generic;
using FootballPrediction.Core.Domain;

namespace FootballPrediction.Core.ApiResponses
{
    public class TeamsResponse : ApiElement
    {
        public IEnumerable<Team> Teams { get; set; }
    }
}