public class ProviderInfoDTO
{
    public string? BusinessPhysicalAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? TouristicOperatorPermitPdf { get; set; }
}

public class ExperienceListDTO
{
    public string? Name { get; set; }
    public int Price { get; set; }
}

public class SharedExperienceListDTO
{
    public string? Name { get; set; }
    public DateTime Date { get; set; }
}

public class SharedExperienceGuestListDTO
{
    public int SharedExperienceId { get; set; }
    public string? GuestName { get; set; }
}

public class PriceStatsDTO
{
    public int MinPrice { get; set; }
    public double AvgPrice { get; set; }
    public int MaxPrice { get; set; }
}

public class ExperienceStatsDTO
{
    public string? Name { get; set; }
    public int GuestCount { get; set; }
    public int TotalSales { get; set; }
}

public class SharedExperienceGuestCountDTO
{
    public string? Name { get; set; }
    public int GuestCount { get; set; }
}

// Add these new DTOs
public class SharedExperienceExperiencesDTO
{
    public string? ExperienceName { get; set; }
}

public class SharedExperienceGuestsDTO
{
    public string? GuestName { get; set; }
}