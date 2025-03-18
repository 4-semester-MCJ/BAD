public class SharedExperienceGuest
{
    public int SharedExperienceId { get; set; }
    public int GuestId { get; set; }

    public required SharedExperience SharedExperience { get; set; }
    public required Guest Guest { get; set; }
}