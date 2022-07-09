using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Word
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }
    public string name { get; set; }
    public DateTime created { get; set; }
    public DateTime? updated { get; set; }
    public int step { get; set; }
    public bool is_done { get; set; }
    public List<Sentence> sentences {get;set;}
}