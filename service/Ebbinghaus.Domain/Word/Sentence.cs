
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Sentence
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }
    public string text { get; set; }
    public DateTime created { get; set; }
    public DateTime? updated { get; set; }

    public Sentence AddOrUpdate(string text, string id)
    {
        Ebbinghaus.Framework.Guard.That(string.IsNullOrEmpty(text), new Exception("Type name."));

        if(string.IsNullOrEmpty(id)){
            created = DateTime.Now;
        }

        updated = DateTime.Now;
        this.text = text;

        return this;
    }
}