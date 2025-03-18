using System.ComponentModel.DataAnnotations;

namespace BAD_MA2_Solution_grp14.Models.DTOs
{
    public class GuestDTO
    {
        public int GuestId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class CreateGuestDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class UpdateGuestDTO
    {
        [StringLength(100)]
        public string? Name { get; set; }
    }
} 