using Microsoft.EntityFrameworkCore;

public class Word
{
    public int id { get; set; }
    public string name { get; set; }
    public DateTime created { get; set; }
    public DateTime? updated { get; set; }
    public int step { get; set; }
    public bool is_done { get; set; }
}