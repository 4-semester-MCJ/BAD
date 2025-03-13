public class SharedExperience
{
    public int SharedExperienceId { get; set; }
    public string? Name { get; set; }
    public DateTime Date { get; set; }

    public ICollection<SharedExperienceDetail> SharedExperienceDetails { get; set; }
    public ICollection<SharedExperienceGuest> SharedExperienceGuests { get; set; }
}