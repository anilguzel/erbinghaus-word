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


    public Word AddOrUpdate(string name, string id, int step = 0, bool is_done = false)
    {
        Ebbinghaus.Framework.Guard.That(string.IsNullOrEmpty(name), new Exception("Type name."));

        if (string.IsNullOrEmpty(id))
        {
            created = DateTime.Now;
            sentences = new List<Sentence>();
        }

        updated = DateTime.Now;
        this.step = step;
        this.is_done = is_done;
        this.name = name;
        return this;
    }

    public Word AddSentence(string text)
    {
        Ebbinghaus.Framework.Guard.That(string.IsNullOrEmpty(text), new Exception("Type text."));

        if (is_done)
        {
            throw new Exception("word already completed");
        }

        if (this.sentences == null)
        {
            this.sentences = new List<Sentence>();
        }

        this.sentences.Add(new Sentence(text));
        PassStep();
        return this;
    }

    public Word UpdateSentence(string text, Guid sentenceId)
    {
        Ebbinghaus.Framework.Guard.That(string.IsNullOrEmpty(text), new Exception("Type text."));

        var sentence = this.sentences.FirstOrDefault(c => c.id == sentenceId);
        if (sentence == null) throw new Exception("sentence not found");

        sentence.text = text;
        sentence.updated = DateTime.Now;
        return this;
    }

    private void PassStep()
    {
        if (step == 3)
        {
            is_done = true;
        }
        else
        {
            this.step++;
        }
    }
}