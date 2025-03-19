using System.ComponentModel.DataAnnotations;

namespace BAD_MA2_Solution_grp14.Models.DTOs
{
    public class SharedExperienceDTO
    {
        public int SharedExperienceId { get; set; }
        public int ExperienceId { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
    }

    public class CreateSharedExperienceDTO
    {
        [Required]
        public int ExperienceId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }

    public class UpdateSharedExperienceDTO
    {
        public DateTime? Date { get; set; }
    }
} 