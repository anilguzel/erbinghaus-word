using Ebbinghaus.Framework;

namespace Ebbinghaus.Domain.Commands
{
    public sealed class UpdateWordSentenceCommand
        : ICommand
    {
        public string WordId { get; set; }
        public Guid SentenceId { get; set; }
        public string Text { get; set; }

        public UpdateWordSentenceCommand(string wordId, Guid sentenceId, string text)
        {
            WordId = wordId;
            SentenceId = sentenceId;
            Text = text;
        }
    }
}