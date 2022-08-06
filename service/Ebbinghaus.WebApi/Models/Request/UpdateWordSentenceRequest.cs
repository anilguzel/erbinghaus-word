using System;

public class UpdateWordSentenceRequest
{
    public Guid WordId { get; set; }
    public Guid SentenceId { get; set; }
    public string Text { get; set; }
}