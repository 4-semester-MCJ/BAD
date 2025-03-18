using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BAD_MA2_Solution_grp14.Models.DTOs;

[Route("api/[controller]")]
[ApiController]
public class ProvidersController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProvidersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProviderDTO>>> GetProviders()
    {
        var providers = await _context.Providers.ToListAsync();
        return providers.Select(p => new ProviderDTO
        {
            ProviderId = p.ProviderId,
            Name = p.Name,
            BuisnessPhysicalAddress = p.BuisnessPhysicalAddress,
            PhoneNumber = p.PhoneNumber,
            TouristicOperatorPermitPdf = p.TouristicOperatorPermitPdf
        }).ToList();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProviderDTO>> GetProvider(int id)
    {
        var provider = await _context.Providers.FindAsync(id);
        if (provider == null) return NotFound();

        return new ProviderDTO
        {
            ProviderId = provider.ProviderId,
            Name = provider.Name,
            BuisnessPhysicalAddress = provider.BuisnessPhysicalAddress,
            PhoneNumber = provider.PhoneNumber,
            TouristicOperatorPermitPdf = provider.TouristicOperatorPermitPdf
        };
    }
}