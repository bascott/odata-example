using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Logging;

namespace ODataPlayground.Controllers
{
    [EnableQuery]
    public class WeatherForecastsController : ODataController
    {
        private readonly ILogger<WeatherForecastsController> _logger;
        private readonly WeatherForecastService _forecastService;


        public WeatherForecastsController(ILogger<WeatherForecastsController> logger, WeatherForecastService forecastService)
        {
            _logger = logger;
            _forecastService = forecastService;


        }

        [HttpGet]
        public IQueryable<WeatherForecast> Get()
        {
            return _forecastService.GetWeatherForecasts().AsQueryable();
        }

        [HttpGet]
        public SingleResult<WeatherForecast> Get([FromODataUri] DateTime key)
        {
            return SingleResult.Create(
                _forecastService.GetWeatherForecasts().Where(e => e.Date == key).AsQueryable());
        }
    }
}
