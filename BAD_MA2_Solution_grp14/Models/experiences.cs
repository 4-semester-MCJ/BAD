public class Experience
{
    public int EId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ProvId { get; set; }
    public decimal Price { get; set; }

    public Provider Provider { get; set; }
    public ICollection<SharedExperienceDetail> SharedExperienceDetails { get; set; }
}