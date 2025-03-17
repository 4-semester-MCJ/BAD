using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ExperiencesController : ControllerBase
{
    private readonly AppDbContext _context;

    // Constructor to inject AppDbContext
    public ExperiencesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/experiences
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Experience>>> GetExperiences()
    {
        // Return all experiences from the database
        return await _context.Experiences.ToListAsync();
    }

    // GET: api/experiences/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Experience>> GetExperience(int id)
    {
        // Find an experience by ID
        var experience = await _context.Experiences.FindAsync(id);
        if (experience == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return experience;
    }

    // POST: api/experiences
    [HttpPost]
    public async Task<ActionResult<Experience>> PostExperience([FromBody] Experience experience)
    {
        // Validate the price field using the custom validation attribute
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Return 400 if invalid
        }

        // Add the new experience to the database
        _context.Experiences.Add(experience);
        await _context.SaveChangesAsync();

        // Return 201 Created response with the new experience and its location
        return CreatedAtAction(nameof(GetExperience), new { id = experience.ExperienceId }, experience);
    }

    // PUT: api/experiences/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutExperience(int id, [FromBody] Experience experience)
    {
        // Check if the experience exists
        var existingExperience = await _context.Experiences.FindAsync(id);
        if (existingExperience == null)
        {
            return NotFound(); // Return 404 if not found
        }

        // Validate the price field again if needed
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Return 400 if invalid
        }

        // Update the properties of the existing experience
        existingExperience.Name = experience.Name;
        existingExperience.Description = experience.Description;
        existingExperience.ProviderId = experience.ProviderId;
        existingExperience.Price = experience.Price;

        // Save the changes to the database
        await _context.SaveChangesAsync();

        // Return 204 No Content as confirmation of successful update
        return NoContent();
    }

    // DELETE: api/experiences/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        // Find the experience by ID
        var experience = await _context.Experiences.FindAsync(id);
        if (experience == null)
        {
            return NotFound(); // Return 404 if not found
        }

        // Remove the experience from the database
        _context.Experiences.Remove(experience);
        await _context.SaveChangesAsync();

        // Return 204 No Content as confirmation of successful deletion
        return NoContent();
    }
}
