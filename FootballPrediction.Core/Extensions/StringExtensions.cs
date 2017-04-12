using System;

namespace FootballPrediction.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Query(this string href)
        {
            return href.Split(new[] { "v1/" }, StringSplitOptions.None)[1];
        }
    }
}
