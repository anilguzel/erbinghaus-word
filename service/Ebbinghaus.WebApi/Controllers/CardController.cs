using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ebbinghaus.Application.Contracts;
using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;
using Ebbinghaus.Application.UseCases;

namespace Ebbinghaus.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{

    [HttpGet]
    public async Task<AllCardsContract> AllCardsAsync([FromServices] ICommandHandler<AllCardsCommand, AllCardsCommandResult> handler)
    {
        var result = await handler.HandleAsync(new AllCardsCommand(), new CancellationToken());
        return result.AllCards;
    }

    [HttpGet]
    public async Task<DailyFeedContract> DailyFeedAsync([FromServices] ICommandHandler<DailyFeedCommand, DailyFeedCommandResult> handler, [FromBody] object request)
    {
        var result = await handler.HandleAsync(new DailyFeedCommand(), new CancellationToken());
        return result.DailyFeed;
    }

}
