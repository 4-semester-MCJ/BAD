using System.ComponentModel.DataAnnotations;

namespace BAD_MA2_Solution_grp14.Models.DTOs
{
    public class SharedExperienceDetailDTO
    {
        public int SharedExperienceDetailId { get; set; }

        [Required]
        public int SharedExperienceId { get; set; }

        [Required]
        public int GuestId { get; set; }
    }

    public class CreateSharedExperienceDetailDTO
    {
        [Required]
        public int SharedExperienceId { get; set; }

        [Required]
        public int GuestId { get; set; }
    }
} 