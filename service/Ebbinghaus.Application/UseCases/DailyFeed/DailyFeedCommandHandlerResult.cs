using Ebbinghaus.Application.Contracts;

namespace Ebbinghaus.Application.UseCases;

public sealed class DailyFeedCommandResult
{
    public DailyFeedContract DailyFeed { get; set; }
}