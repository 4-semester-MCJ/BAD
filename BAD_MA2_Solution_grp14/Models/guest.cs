public class Guest
{
    public int GId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string PhoneNum { get; set; }

    public ICollection<SharedExperienceGuest> SharedExperienceGuests { get; set; }
}
