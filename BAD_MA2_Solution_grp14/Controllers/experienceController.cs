using Microsoft.AspNetCore.Mvc;
using experiencesAPI;

namespace WebAPI.Controllers;

[Route("exp")]
[ApiController]
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

