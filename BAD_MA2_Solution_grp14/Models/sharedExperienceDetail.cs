public class SharedExperienceDetail
{
    public int SEId { get; set; }
    public int EId { get; set; }

    public SharedExperience SharedExperience { get; set; }
    public Experience Experience { get; set; }
}