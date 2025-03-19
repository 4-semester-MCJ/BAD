using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class ProviderDTO
    {
        public int ProviderId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? BPA { get; set; }
        public string? TouristsPermit { get; set; }
        public string? Description { get; set; }
    }

    public class ProviderQueryDTO
    {
        public string? TouristsPermit { get; set; }
        public string? BPA { get; set; }
        public string? PhoneNumber { get; set; }
    }
} 