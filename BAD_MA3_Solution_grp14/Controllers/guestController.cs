using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BAD_MA3_Solution_grp14.Models.DTOs;

[Route("api/[controller]")]
[ApiController]
public class GuestsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GuestsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GuestDTO>>> GetGuests()
    {
        var guests = await _context.Guests.ToListAsync();
        return guests.Select(g => new GuestDTO
        {
            GuestId = g.GuestId,
            Name = g.Name
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GuestDTO>> GetGuest(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        if (guest == null) return NotFound();
        
        return new GuestDTO
        {
            GuestId = guest.GuestId,
            Name = guest.Name
        };
    }

}
