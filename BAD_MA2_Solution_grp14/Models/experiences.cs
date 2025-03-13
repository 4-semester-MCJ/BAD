public class Experience
{
    public int ExperienceId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ProviderId { get; set; } // foreign key
    public decimal Price { get; set; }

    public Provider Provider { get; set; }
    public ICollection<SharedExperienceDetail> SharedExperienceDetails { get; set; }
}