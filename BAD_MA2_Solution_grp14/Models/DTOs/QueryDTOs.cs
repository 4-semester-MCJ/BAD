using System.ComponentModel.DataAnnotations;

namespace BAD_MA2_Solution_grp14.Models.DTOs
{
    public class ProviderInfoDTO
    {
        public string BusinessPhysicalAddress { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ExperienceListDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class PriceStatsDTO
    {
        public int MinPrice { get; set; }
        public double AvgPrice { get; set; }
        public int MaxPrice { get; set; }
    }

    public class SharedExperienceListDTO
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }

    public class SharedExperienceGuestListDTO
    {
        public int SharedExperienceId { get; set; }
        public string GuestName { get; set; }
    }
} 