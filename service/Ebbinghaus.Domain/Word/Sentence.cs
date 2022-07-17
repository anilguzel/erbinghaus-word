
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Sentence
{
    public Guid id { get; set; }
    public string text { get; set; }
    public DateTime created { get; set; }
    public DateTime? updated { get; set; }

    public Sentence(string text)
    {
        this.id = Guid.NewGuid();
        this.text = text;
        created = DateTime.Now;
    }
}