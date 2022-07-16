using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
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
    public List<Sentence> sentences { get; set; }


    public Word AddOrUpdate(string name, string id)
    {
        Ebbinghaus.Framework.Guard.That(string.IsNullOrEmpty(name), new Exception("Type name."));

        if (string.IsNullOrEmpty(id))
        {
            created = DateTime.Now;
        }
        
        step = 0;
        is_done = false;
        sentences = new List<Sentence>();

        return this;
    }
}