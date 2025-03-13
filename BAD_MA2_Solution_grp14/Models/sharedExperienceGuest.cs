public class SharedExperienceGuest
{
    public int SEId { get; set; }
    public int GId { get; set; }

    public SharedExperience SharedExperience { get; set; }
    public Guest Guest { get; set; }
}