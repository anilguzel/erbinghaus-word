using Ebbinghaus.Application.Contracts;
using Ebbinghaus.Framework;

namespace Ebbinghaus.Application.UseCases;

public sealed class CreateWordSentenceCommandHandlerResult : ICommandHandlerResult
{
    public bool is_success { get; set; }
    public string message { get; set; } = "";
}