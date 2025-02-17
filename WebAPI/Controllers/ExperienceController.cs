using Microsoft.AspNetCore.Mvc;
using experiencesAPI;

namespace assignment1.Controllers;

    [ApiController]
    [Route("exp")] // api/experiences
    public class ExperiencesController : ControllerBase 
    {
        // GET endpoint
        [HttpGet]
        public ActionResult<IEnumerable<Experience>> Get()
        {
            var experience = new List<Experience>
            {
                new Experience { 
                    Name = "Local Watering Hole", 
                    Description = "Includes a trip to KK", 
                    Price = 500 },

                new Experience { 
                    Name = "Skydiving", 
                    Description = "Fall out from a plane", 
                    Price = 2500 },
                
                new Experience {
                    Name = "Authentic Coffee Farm", 
                    Description = "A little animal eats the best beans and then you go find the best beans", 
                    Price = 300 }

            };
            return Ok(experience);
        }
    }

// [ApiController]
// [Route("[controller]")]
// public class WeatherForecastController : ControllerBase
// {
//     private static readonly string[] Summaries = new[]
//     {
//         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//     };

//     private readonly ILogger<WeatherForecastController> _logger;

//     public WeatherForecastController(ILogger<WeatherForecastController> logger)
//     {
//         _logger = logger;
//     }

//     [HttpGet(Name = "GetWeatherForecast")]
//     public IEnumerable<WeatherForecast> Get()
//     {
//         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//         {
//             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             TemperatureC = Random.Shared.Next(-20, 55),
//             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//         })
//         .ToArray();
//     }
// }


