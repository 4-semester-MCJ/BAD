using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ActionResult<IEnumerable<SharedExperience>>> GetSharedExperiences()
    {
        return await _context.SharedExperiences
            .Include(se => se.SharedExperienceDetails)
            .Include(se => se.SharedExperienceGuests)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SharedExperience>> GetSharedExperience(int id)
    {
        var se = await _context.SharedExperiences
            .Include(x => x.SharedExperienceDetails)
            .Include(x => x.SharedExperienceGuests)
            .FirstOrDefaultAsync(x => x.SharedExperienceId == id);

        if (se == null) return NotFound();
        return se;
    }
}
