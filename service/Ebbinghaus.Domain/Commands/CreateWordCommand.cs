
using System;
using Ebbinghaus.Framework;

namespace Ebbinghaus.Domain.Commands
{
    public sealed class CreateWordCommand
        : ICommand
    {
        public string Name { get; set; }

        public CreateWordCommand(string name)
        {
            Name = name;
        }
    }
}