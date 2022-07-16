
using Ebbinghaus.Application.Contracts;

namespace Ebbinghaus.Application.UseCases;

public sealed class AllCardsCommandHandlerResult
{
    public AllCardsContract AllCards { get; set; }
}