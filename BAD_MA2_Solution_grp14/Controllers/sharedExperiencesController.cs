using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BAD_MA2_Solution_grp14.Models.DTOs;

[Route("api/[controller]")]
[ApiController]
public class SharedExperiencesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SharedExperiencesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SharedExperienceDTO>>> GetSharedExperiences()
    {
        var sharedExperiences = await _context.SharedExperiences
            .Include(se => se.SharedExperienceDetails)
            .ToListAsync();
            
        return sharedExperiences.Select(se => new SharedExperienceDTO
        {
            SharedExperienceId = se.SharedExperienceId,
            ExperienceId = se.SharedExperienceDetails.FirstOrDefault()?.ExperienceId ?? 0,
            Date = se.Date
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SharedExperienceDTO>> GetSharedExperience(int id)
    {
        var se = await _context.SharedExperiences
            .Include(x => x.SharedExperienceDetails)
            .FirstOrDefaultAsync(x => x.SharedExperienceId == id);

        if (se == null) return NotFound();
        
        return new SharedExperienceDTO
        {
            SharedExperienceId = se.SharedExperienceId,
            ExperienceId = se.SharedExperienceDetails.FirstOrDefault()?.ExperienceId ?? 0,
            Date = se.Date
        };
    }

    





    
}
