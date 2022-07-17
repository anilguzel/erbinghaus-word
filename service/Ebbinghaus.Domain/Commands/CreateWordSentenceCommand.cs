
using System;
using Ebbinghaus.Framework;

namespace Ebbinghaus.Domain.Commands
{
    public sealed class CreateWordSentenceCommand
        : ICommand
    {
        public string WordId { get; set; }
        public string Text { get; set; }

        public CreateWordSentenceCommand(string wordId, string text)
        {
            WordId = wordId;
            Text = text;
        }
    }
}