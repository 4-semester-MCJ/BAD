using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class LogsController : ControllerBase
{
    private readonly IMongoCollection<LogEntry> _logCollection;

    public LogsController(IMongoDatabase database)
    {
        _logCollection = database.GetCollection<LogEntry>("Logs");
    }

        [HttpGet("search")]
public async Task<ActionResult<IEnumerable<LogEntry>>> SearchLogs(
    [FromQuery] string? user,
    [FromQuery] DateTime? startTime,
    [FromQuery] DateTime? endTime,
    [FromQuery] string? operation)
{
    Console.WriteLine("SearchLogs endpoint hit");
    Console.WriteLine($"Parameters - User: {user}, StartTime: {startTime}, EndTime: {endTime}, Operation: {operation}");

    var filterBuilder = Builders<LogEntry>.Filter;
    var filter = filterBuilder.Empty;

    // Filter by user
    if (!string.IsNullOrEmpty(user))
    {
        filter &= filterBuilder.Eq(log => log.User, user);
    }

    // Filter by date range
    if (startTime.HasValue || endTime.HasValue)
    {
        var dateFilter = filterBuilder.Empty;

        if (startTime.HasValue)
        {
            var startUtc = DateTime.SpecifyKind(startTime.Value, DateTimeKind.Utc);
            Console.WriteLine("Using StartTime UTC: " + startUtc.ToString("o"));
            dateFilter &= filterBuilder.Gte(log => log.Timestamp, startUtc);
        }

        if (endTime.HasValue)
        {
            var endUtc = DateTime.SpecifyKind(endTime.Value, DateTimeKind.Utc);
            Console.WriteLine("Using EndTime UTC: " + endUtc.ToString("o"));
            dateFilter &= filterBuilder.Lte(log => log.Timestamp, endUtc);
        }

        filter &= dateFilter;
    }

    // Filter by operation
    if (!string.IsNullOrEmpty(operation))
    {
        filter &= filterBuilder.Eq(log => log.Operation, operation);
    }

    Console.WriteLine($"Final MongoDB Filter: {filter.ToBsonDocument().ToJson()}");

    // Fetch logs from MongoDB
    var logs = await _logCollection.Find(filter).ToListAsync();

    Console.WriteLine($"Logs fetched: {logs.Count}");
    foreach (var log in logs)
    {
        Console.WriteLine($"Log - User: {log.User}, Operation: {log.Operation}, Timestamp: {log.Timestamp}, Details: {log.Details}");
    }

    return Ok(logs);
}

}