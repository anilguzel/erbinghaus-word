using Microsoft.EntityFrameworkCore;

public class Sentence
{
    public int id { get; set; }
    public int word_id { get; set; }
    public string text { get; set; }
    public DateTime created { get; set; }
    public DateTime? updated { get; set; }
}