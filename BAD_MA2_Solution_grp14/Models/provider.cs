public class Provider
{
    public int ProviderId { get; set; }
    public string? Name { get; set; }
    public string? BuisnessPhysicalAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CVR { get; set; }

    public string? TouristicOperatorPerimt { get; set; }

    public ICollection<Experience> Experiences { get; set; }
}