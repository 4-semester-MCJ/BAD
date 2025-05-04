using BAD_MA3_Solution_grp14.Models.DTOs;

namespace BAD_MA3_Solution_grp14.Services
{
    public interface ILogService
    {
        Task LogQueryAsync(LogEntryDTO logEntry);
        Task<IEnumerable<LogEntryDTO>> SearchLogsAsync(LogEntrySearchDTO searchParams);
    }
}