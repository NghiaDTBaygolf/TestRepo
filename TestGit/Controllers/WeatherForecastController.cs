using System.Numerics;
using Microsoft.AspNetCore.Mvc;

namespace TestGit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost("GiaiThua")]
        public async Task<IActionResult> GiaiThua([FromBody] int number)
        {
            if (number < 0)
                return BadRequest("Number must be non-negative.");
            if (number > 65)
            {
                return BadRequest("Number must be less than or equal to 65.");
            }
            var result = Dequy(number);
            return Ok(result);
        }

        private long Dequy(int number)
        {
            if (number == 0 || number == 1)
                return 1;
            return number * Dequy(number - 1);
        }
    }
}
