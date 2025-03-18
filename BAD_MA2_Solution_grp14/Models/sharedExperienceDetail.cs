public class SharedExperienceDetail
{
    public int SharedExperienceId { get; set; }
    public int ExperienceId { get; set; }

    public required SharedExperience SharedExperience { get; set; }
    public required Experience Experience { get; set; }
}