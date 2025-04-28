using System.ComponentModel.DataAnnotations;

namespace BAD_MA3_Solution_grp14.Models.DTOs
{
    public class ExperienceDTO
    {
        public int ExperienceId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int ProviderId { get; set; }
        public int Price { get; set; }
    }

    public class CreateExperienceDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }

    public class UpdateExperienceDTO
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int? Price { get; set; }
    }
} 