public class SharedExperienceGuest
{
    public int SharedExperienceId { get; set; }
    public int GuestId { get; set; }

    public SharedExperience SharedExperience { get; set; }
    public Guest Guest { get; set; }
}