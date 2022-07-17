using Ebbinghaus.Framework;

namespace Ebbinghaus.Domain.Commands
{
    public sealed class UpdateWordCommand
        : ICommand
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public UpdateWordCommand(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}