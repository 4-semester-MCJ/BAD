using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAD_MA2_Solution_grp14.Models.DTOs;

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
    public async Task<ActionResult<IEnumerable<ExperienceDTO>>> GetExperiences()
    {
        var experiences = await _context.Experiences.ToListAsync();
        return experiences.Select(e => new ExperienceDTO
        {
            ExperienceId = e.ExperienceId,
            Name = e.Name,
            Description = e.Description,
            ProviderId = e.ProviderId,
            Price = e.Price
        }).ToList();
    }

    // GET: api/experiences/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ExperienceDTO>> GetExperience(int id)
    {
        var experience = await _context.Experiences.FindAsync(id);
        if (experience == null)
        {
            return NotFound();
        }

        return new ExperienceDTO
        {
            ExperienceId = experience.ExperienceId,
            Name = experience.Name,
            Description = experience.Description,
            ProviderId = experience.ProviderId,
            Price = experience.Price
        };
    }

    // POST: api/experiences
    [HttpPost]
    public async Task<ActionResult<ExperienceDTO>> PostExperience([FromBody] CreateExperienceDTO createDto)
    {
        var experience = new Experience
        {
            Name = createDto.Name,
            Description = createDto.Description,
            ProviderId = createDto.ProviderId,
            Price = createDto.Price
        };

        _context.Experiences.Add(experience);
        await _context.SaveChangesAsync();

        var resultDto = new ExperienceDTO
        {
            ExperienceId = experience.ExperienceId,
            Name = experience.Name,
            Description = experience.Description,
            ProviderId = experience.ProviderId,
            Price = experience.Price
        };

        return CreatedAtAction(nameof(GetExperience), new { id = resultDto.ExperienceId }, resultDto);
    }

    // PUT: api/experiences/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutExperience(int id, [FromBody] UpdateExperienceDTO updateDto)
    {
        var experience = await _context.Experiences.FindAsync(id);
        if (experience == null)
        {
            return NotFound();
        }

        // Only update properties that are provided in the DTO
        if (updateDto.Name != null)
            experience.Name = updateDto.Name;
        if (updateDto.Description != null)
            experience.Description = updateDto.Description;
        if (updateDto.Price.HasValue)
            experience.Price = updateDto.Price.Value;

        await _context.SaveChangesAsync();
        return NoContent();
    }

// DELETE: api/experiences/{id}
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteExperience(int id)
{
    var experience = await _context.Experiences.FindAsync(id);
    if (experience == null)
    {
        return NotFound();
    }

    _context.Experiences.Remove(experience);
    await _context.SaveChangesAsync();

    // Find max ID in table
    var maxId = await _context.Experiences.MaxAsync(e => (int?)e.ExperienceId) ?? 0;

    // Reseed ID to Max ID
    await _context.Database.ExecuteSqlRawAsync($"DBCC CHECKIDENT ('Experiences', RESEED, {maxId})");

    return NoContent();
}
}
