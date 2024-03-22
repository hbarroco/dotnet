using LoginJWT_Sample_API.Models;
using LoginLogoutJWT_Sample.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LoginJWT_Sample_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecastDto> Get()
        {
            _logger.LogInfo("Here is WeatherForecastController -> GetWeatherForecast.");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
