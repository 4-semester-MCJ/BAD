using MongoDB.Driver;
using BAD_MA3_Solution_grp14.Models.DTOs;

namespace BAD_MA3_Solution_grp14.Services
{
    public class MongoLogService : ILogService
    {
        private readonly IMongoCollection<LogEntryDTO> _logEntries;

        public MongoLogService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            var database = client.GetDatabase("LoggingDB");
            _logEntries = database.GetCollection<LogEntryDTO>("LogEntries");
        }

        public async Task LogQueryAsync(LogEntryDTO logEntry)
        {
            await _logEntries.InsertOneAsync(logEntry);
        }

        public async Task<IEnumerable<LogEntryDTO>> SearchLogsAsync(LogEntrySearchDTO searchParams)
        {
            var filter = Builders<LogEntryDTO>.Filter.Empty;

            if (!string.IsNullOrEmpty(searchParams.Action))
            {
                filter &= Builders<LogEntryDTO>.Filter.Regex(x => x.Action, new MongoDB.Bson.BsonRegularExpression(searchParams.Action, "i"));
            }

            if (!string.IsNullOrEmpty(searchParams.EntityType))
            {
                filter &= Builders<LogEntryDTO>.Filter.Regex(x => x.EntityType, new MongoDB.Bson.BsonRegularExpression(searchParams.EntityType, "i"));
            }

            if (!string.IsNullOrEmpty(searchParams.EntityId))
            {
                filter &= Builders<LogEntryDTO>.Filter.Regex(x => x.EntityId, new MongoDB.Bson.BsonRegularExpression(searchParams.EntityId, "i"));
            }

            if (!string.IsNullOrEmpty(searchParams.UserId))
            {
                filter &= Builders<LogEntryDTO>.Filter.Regex(x => x.UserId, new MongoDB.Bson.BsonRegularExpression(searchParams.UserId, "i"));
            }

            if (searchParams.StartDate.HasValue)
            {
                filter &= Builders<LogEntryDTO>.Filter.Gte(x => x.Timestamp, searchParams.StartDate.Value);
            }

            if (searchParams.EndDate.HasValue)
            {
                filter &= Builders<LogEntryDTO>.Filter.Lte(x => x.Timestamp, searchParams.EndDate.Value);
            }

            var sort = Builders<LogEntryDTO>.Sort.Descending(x => x.Timestamp);

            return await _logEntries.Find(filter)
                .Sort(sort)
                .ToListAsync();
        }
    }
}