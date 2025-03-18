using System.ComponentModel.DataAnnotations;

namespace BAD_MA2_Solution_grp14.Models.DTOs
{
    public class SharedExperienceGuestDTO
    {
        public int SharedExperienceGuestId { get; set; }

        [Required]
        public int SharedExperienceId { get; set; }

        [Required]
        public int GuestId { get; set; }
    }

    public class CreateSharedExperienceGuestDTO
    {
        [Required]
        public int SharedExperienceId { get; set; }

        [Required]
        public int GuestId { get; set; }
    }
} 