public class Provider
{
    public int ProvId { get; set; }
    public string Name { get; set; }
    public string BPA { get; set; } // Business Physical Address
    public string PhoneNum { get; set; }
    public string CVR { get; set; }

    public ICollection<Experience> Experiences { get; set; }
}