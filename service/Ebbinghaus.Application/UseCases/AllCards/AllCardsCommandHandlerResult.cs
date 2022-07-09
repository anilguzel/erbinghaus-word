
using Ebbinghaus.Application.Contracts;

namespace Ebbinghaus.Application.UseCases;

public sealed class AllCardsCommandResult
{
    public AllCardsContract AllCards { get; set; }
}