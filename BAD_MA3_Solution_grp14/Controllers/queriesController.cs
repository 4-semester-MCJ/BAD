using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BAD_MA3_Solution_grp14.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Authorization.Infrastructure;


[Route("api/[controller]")]
[ApiController]
public class QueriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public QueriesController(AppDbContext context)
    {
        _context = context;
    }

    // 1. Get provider data - only available to Managers and Admins
    [HttpGet("providers-info")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<ActionResult<IEnumerable<ProviderInfoDTO>>> GetProviderDetails()
    {
        var result = await _context.Providers
            .Select(p => new ProviderInfoDTO
            {
                BusinessPhysicalAddress = p.BuisnessPhysicalAddress,
                PhoneNumber = p.PhoneNumber,
                TouristicOperatorPermitPdf = p.TouristicOperatorPermitPdf
            })
            .ToListAsync();
        return Ok(result);
    }

    // 2. List experiences with price - available to anonymous users
    [HttpGet("experiences-list")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ExperienceListDTO>>> GetExperiencesList()
    {
        var result = await _context.Experiences
            .Select(e => new ExperienceListDTO
            {
                Name = e.Name,
                Price = e.Price
            })
            .ToListAsync();
        return Ok(result);
    }

    // 3. List shared experiences ordered by date - available to anonymous users
    [HttpGet("shared-experiences")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<SharedExperienceListDTO>>> GetSharedExperiences()
    {
        var result = await _context.SharedExperiences
            .OrderBy(se => se.Date)
            .Select(se => new SharedExperienceListDTO
            {
                Name = se.Name,
                Date = se.Date
            })
            .ToListAsync();
        return Ok(result);
    }

    // 4. Guests for shared experiences - only available to Managers and Admins
    [HttpGet("shared-experiences/guests")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<ActionResult<IEnumerable<SharedExperienceGuestListDTO>>> GetGuestsForSharedExperiences()
    {
        var result = await _context.SharedExperienceGuests
            .Include(seg => seg.Guest)
            .OrderBy(seg => seg.SharedExperienceId)
            .Select(seg => new SharedExperienceGuestListDTO
            {
                SharedExperienceId = seg.SharedExperienceId,
                GuestName = seg.Guest.Name
            })
            .ToListAsync();
        return Ok(result);
    }

    // 5. Experiences in a specific shared experience - available to anonymous users
    [HttpGet("shared-experiences/{name}/experiences")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<SharedExperienceExperiencesDTO>>> GetExperiencesInSharedExperience(string name)
    {
        var result = await _context.SharedExperienceDetails
            .Include(d => d.Experience)
            .Include(d => d.SharedExperience)
            .Where(d => d.SharedExperience.Name == name)
            .Select(d => new SharedExperienceExperiencesDTO
            {
                ExperienceName = d.Experience.Name
            })
            .ToListAsync();
        return Ok(result);
    }

    // 6. Guests registered in a specific shared experience - only available to Managers and Admins
    [HttpGet("shared-experiences/{name}/guests")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<ActionResult<IEnumerable<SharedExperienceGuestsDTO>>> GetGuestsInSharedExperience(string name)
    {
        var result = await _context.SharedExperienceGuests
            .Include(g => g.Guest)
            .Include(g => g.SharedExperience)
            .Where(g => g.SharedExperience.Name == name)
            .Select(g => new SharedExperienceGuestsDTO
            {
                GuestName = g.Guest.Name
            })
            .ToListAsync();
        return Ok(result);
    }

    // 7. Min, avg, max price - only available to Managers and Admins
    [HttpGet("experiences/price-stats")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<ActionResult<PriceStatsDTO>> GetPriceStats()
    {
        var result = new PriceStatsDTO
        {
            MinPrice = await _context.Experiences.MinAsync(e => e.Price),
            MaxPrice = await _context.Experiences.MaxAsync(e => e.Price),
            AvgPrice = await _context.Experiences.AverageAsync(e => e.Price)
        };
        return Ok(result);
    }

    // 8. Guest count and sales per experience - only available to Managers and Admins
    [HttpGet("experiences/guests-sales")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<ActionResult<IEnumerable<ExperienceStatsDTO>>> GetGuestsAndSalesPerExperience()
    {
        var experiences = await _context.Experiences
            .Include(e => e.SharedExperienceDetails)
                .ThenInclude(d => d.SharedExperience)
                    .ThenInclude(se => se.SharedExperienceGuests)
            .ToListAsync(); // Fetches data first

        var result = experiences.Select(e =>
        {
            var guests = e.SharedExperienceDetails?
                .SelectMany(d => d.SharedExperience?.SharedExperienceGuests ?? new List<SharedExperienceGuest>())
                .ToList() ?? new List<SharedExperienceGuest>();

            return new ExperienceStatsDTO
            {
                Name = e.Name,
                GuestCount = guests.Count,
                TotalSales = e.Price * guests.Count
            };
        }).ToList();

        return Ok(result);
    }


    // 9. Shared experiences with more than one guest - only available to Managers and Admins
    [HttpGet("shared-experiences/multiple-guests")]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<ActionResult<IEnumerable<SharedExperienceGuestCountDTO>>> GetSharedExperiencesWithManyGuests()
    {
        var result = await _context.SharedExperiences
            .Select(se => new SharedExperienceGuestCountDTO
            {
                Name = se.Name,
                GuestCount = se.SharedExperienceGuests.Count()
            })
            .Where(x => x.GuestCount > 1)
            .ToListAsync();
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("logentries")]
    public async Task<ActionResult<IEnumerable<LogEntryDTO>>> GetLogEntries([FromQuery] LogEntrySearchDTO searchParams)
    {
        var query = _context.LogEntries.AsQueryable();

        // Apply search filters
        if (!string.IsNullOrEmpty(searchParams.Action))
        {
            query = query.Where(l => l.Action.Contains(searchParams.Action));
        }

        if (!string.IsNullOrEmpty(searchParams.EntityType))
        {
            query = query.Where(l => l.EntityType.Contains(searchParams.EntityType));
        }

        if (!string.IsNullOrEmpty(searchParams.EntityId))
        {
            query = query.Where(l => l.EntityId.Contains(searchParams.EntityId));
        }

        if (!string.IsNullOrEmpty(searchParams.UserId))
        {
            query = query.Where(l => l.UserId.Contains(searchParams.UserId));
        }

        if (searchParams.StartDate.HasValue)
        {
            query = query.Where(l => l.Timestamp >= searchParams.StartDate.Value);
        }

        if (searchParams.EndDate.HasValue)
        {
            query = query.Where(l => l.Timestamp <= searchParams.EndDate.Value);
        }

        // Order by timestamp descending (most recent first)
        query = query.OrderByDescending(l => l.Timestamp);

        var result = await query
            .Select(l => new LogEntryDTO
            {
                LogEntryId = l.LogEntryId,
                Action = l.Action,
                EntityType = l.EntityType,
                EntityId = l.EntityId,
                UserId = l.UserId,
                Timestamp = l.Timestamp,
                Details = l.Details
            })
            .ToListAsync();

        return Ok(result);
    }
}