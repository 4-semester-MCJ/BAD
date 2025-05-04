using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class LogEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } // MongoDB ObjectId
    public string User { get; set; }
    public string Operation { get; set; } // POST, PUT, DELETE
    public DateTime Timestamp { get; set; }
    public string Details { get; set; }
}