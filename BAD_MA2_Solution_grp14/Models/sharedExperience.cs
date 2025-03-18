public class SharedExperience
{
    public int SharedExperienceId { get; set; }
    public string? Name { get; set; }
    public DateTime Date { get; set; }

    public required ICollection<SharedExperienceDetail> SharedExperienceDetails { get; set; }
    public required ICollection<SharedExperienceGuest> SharedExperienceGuests { get; set; }
}