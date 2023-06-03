using AuthTemplateProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthTemplateProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfigAndEnv _configAndEnv;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfigAndEnv configAndEnv)
        {
            _logger = logger;
            _configAndEnv = configAndEnv;
        }

        [HttpGet]
        [Route("/getTemp")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("/getConfig")]
        public IEnumerable<String> GetConfigAndEnv()
        {
            return _configAndEnv.get();
        }
    }
}