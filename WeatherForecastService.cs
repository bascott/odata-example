using System;
using System.Collections.Generic;
using System.Linq;

namespace ODataPlayground
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly IEnumerable<WeatherForecast> _forcasts;

        static WeatherForecastService()
        {
            var rng = new Random();
            _forcasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.Date.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return _forcasts;
        }
    }
}