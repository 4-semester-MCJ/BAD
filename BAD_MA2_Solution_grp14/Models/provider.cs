public class Provider
{
    public int ProviderId { get; set; }
    public string? Name { get; set; }
    public string? BuisnessPhysicalAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? TouristicOperatorPermitPdf { get; set; } // New column for the permit PDF

    public ICollection<Experience> Experiences { get; set; }
}