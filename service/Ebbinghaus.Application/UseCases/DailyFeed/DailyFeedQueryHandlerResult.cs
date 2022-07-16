using Ebbinghaus.Application.Contracts;

namespace Ebbinghaus.Application.UseCases;

public sealed class DailyFeedQueryHandlerResult
{
    public DailyFeedContract DailyFeed { get; set; }
}