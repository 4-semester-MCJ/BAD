using System.Security.Claims;
using BAD_MA3_Solution_grp14.Models.DTOs;
using BAD_MA3_Solution_grp14.Services;

namespace BAD_MA3_Solution_grp14.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MongoLogService _logService;

        public RequestLoggingMiddleware(RequestDelegate next, MongoLogService logService)
        {
            _next = next;
            _logService = logService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Get the user ID from the claims
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";

            // Create log entry
            var logEntry = new LogEntryDTO
            {
                Action = $"{context.Request.Method} {context.Request.Path}",
                EntityType = "API",
                EntityId = context.Request.Path,
                UserId = userId,
                Timestamp = DateTime.UtcNow,
                Details = $"Request from {context.Connection.RemoteIpAddress}"
            };

            // Log the request
            await _logService.LogQueryAsync(logEntry);

            // Continue processing the request
            await _next(context);
        }
    }
}