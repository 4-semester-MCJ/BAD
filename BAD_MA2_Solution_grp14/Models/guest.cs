public class Guest
{
    public int GuestId { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? PhoneNumber { get; set; }

    public ICollection<SharedExperienceGuest> SharedExperienceGuests { get; set; }
}
