
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Sentence
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }
    public string text { get; set; }
    public DateTime created { get; set; }
    public DateTime? updated { get; set; }
}