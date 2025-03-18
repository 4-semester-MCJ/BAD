using System.ComponentModel.DataAnnotations;

namespace BAD_MA2_Solution_grp14.Models.DTOs
{
    public class ProviderDTO
    {
        public int ProviderId { get; set; }
        public required string Name { get; set; }
        public string? BuisnessPhysicalAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TouristicOperatorPermitPdf { get; set; }
    }

    public class CreateProviderDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class UpdateProviderDTO
    {
        [StringLength(100)]
        public string? Name { get; set; }
    }
} 