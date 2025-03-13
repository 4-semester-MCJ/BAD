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
    public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
    {
        return await _context.Guests.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> GetGuest(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        if (guest == null) return NotFound();
        return guest;
    }
}
