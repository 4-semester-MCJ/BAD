public class Experience
{
    public int ExperienceId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ProviderId { get; set; } // foreign key, should remain as it is.

    [NoneNegative] // Custom validation attribute.
    public int Price { get; set; }

    public Provider? Provider { get; set; } // Make this nullable if not always required.
    public ICollection<SharedExperienceDetail>? SharedExperienceDetails { get; set; } // Make this nullable if not always required.
}
