public class SharedExperienceDetail
{
    public int SharedExperienceId { get; set; }
    public int ExperienceId { get; set; }
    public SharedExperience? SharedExperience { get; set; }
    public Experience? Experience { get; set; }
}