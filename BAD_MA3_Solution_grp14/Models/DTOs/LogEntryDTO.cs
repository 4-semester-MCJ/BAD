using System.ComponentModel.DataAnnotations;

namespace BAD_MA3_Solution_grp14.Models.DTOs
{
    public class LogEntryDTO
    {
        public int LogEntryId { get; set; }
        public string? Action { get; set; }
        public string? EntityType { get; set; }
        public string? EntityId { get; set; }
        public string? UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Details { get; set; }
    }

    public class LogEntrySearchDTO
    {
        public string? Action { get; set; }
        public string? EntityType { get; set; }
        public string? EntityId { get; set; }
        public string? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}