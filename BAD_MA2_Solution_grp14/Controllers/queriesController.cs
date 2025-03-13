using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class QueriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public QueriesController(AppDbContext context)
    {
        _context = context;
    }

    // 1. Get provider data
    [HttpGet("providers-info")]
    public async Task<IActionResult> GetProviderDetails()
    {
        var result = await _context.Providers
            .Select(p => new { p.BPA, p.PhoneNum, p.CVR })
            .ToListAsync();
        return Ok(result);
    }

    // 2. List experiences with price
    [HttpGet("experiences-list")]
    public async Task<IActionResult> GetExperiencesList()
    {
        var result = await _context.Experiences
            .Select(e => new { e.Name, e.Price })
            .ToListAsync();
        return Ok(result);
    }

    // 3. List shared experiences ordered by date
    [HttpGet("shared-experiences")]
    public async Task<IActionResult> GetSharedExperiences()
    {
        var result = await _context.SharedExperiences
            .OrderBy(se => se.Date)
            .Select(se => new { se.Name, se.Date })
            .ToListAsync();
        return Ok(result);
    }

    // 4. Guests for shared experiences
    [HttpGet("shared-experiences/guests")]
    public async Task<IActionResult> GetGuestsForSharedExperiences()
    {
        var result = await _context.SharedExperienceGuests
            .Include(seg => seg.Guest)
            .OrderBy(seg => seg.SEId)
            .Select(seg => new { seg.SEId, GuestName = seg.Guest.Name })
            .ToListAsync();
        return Ok(result);
    }

    // 5. Experiences in a specific shared experience
    [HttpGet("shared-experiences/{name}/experiences")]
    public async Task<IActionResult> GetExperiencesInSharedExperience(string name)
    {
        var result = await _context.SharedExperienceDetails
            .Include(d => d.Experience)
            .Include(d => d.SharedExperience)
            .Where(d => d.SharedExperience.Name == name)
            .Select(d => new { Experience = d.Experience.Name })
            .ToListAsync();
        return Ok(result);
    }

    // 6. Guests registered in a specific shared experience
    [HttpGet("shared-experiences/{name}/guests")]
    public async Task<IActionResult> GetGuestsInSharedExperience(string name)
    {
        var result = await _context.SharedExperienceGuests
            .Include(g => g.Guest)
            .Include(g => g.SharedExperience)
            .Where(g => g.SharedExperience.Name == name)
            .Select(g => new { GuestName = g.Guest.Name })
            .ToListAsync();
        return Ok(result);
    }

    // 7. Min, avg, max price
    [HttpGet("experiences/price-stats")]
    public async Task<IActionResult> GetPriceStats()
    {
        var min = await _context.Experiences.MinAsync(e => e.Price);
        var max = await _context.Experiences.MaxAsync(e => e.Price);
        var avg = await _context.Experiences.AverageAsync(e => e.Price);
        return Ok(new { MinPrice = min, AvgPrice = avg, MaxPrice = max });
    }

    // 8. Guest count and sales per experience
    [HttpGet("experiences/guests-sales")]
    public async Task<IActionResult> GetGuestsAndSalesPerExperience()
    {
        var result = await _context.Experiences
            .Select(e => new
            {
                Experience = e.Name,
                NumberOfGuests = _context.SharedExperienceDetails
                    .Where(d => d.EId == e.EId)
                    .SelectMany(d => _context.SharedExperienceGuests.Where(g => g.SEId == d.SEId))
                    .Count(),
                TotalSales = e.Price * _context.SharedExperienceDetails
                    .Where(d => d.EId == e.EId)
                    .SelectMany(d => _context.SharedExperienceGuests.Where(g => g.SEId == d.SEId))
                    .Count()
            }).ToListAsync();
        return Ok(result);
    }

    // 9. Shared experiences with more than one guest
    [HttpGet("shared-experiences/multiple-guests")]
    public async Task<IActionResult> GetSharedExperiencesWithManyGuests()
    {
        var result = await _context.SharedExperiences
            .Select(se => new
            {
                se.Name,
                GuestCount = _context.SharedExperienceGuests.Count(g => g.SEId == se.SEId)
            })
            .Where(x => x.GuestCount > 1)
            .ToListAsync();
        return Ok(result);
    }
}