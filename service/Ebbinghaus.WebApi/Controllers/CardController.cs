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

    [HttpGet("all")]
    public async Task<AllCardsContract> AllCardsAsync([FromServices] ICommandHandler<AllCardsCommand, AllCardsCommandHandlerResult> handler)
    {
        var result = await handler.HandleAsync(new AllCardsCommand(), new CancellationToken());
        return result.AllCards;
    }

    [HttpGet("feed")]
    public async Task<DailyFeedContract> DailyFeedAsync([FromServices] IQueryHandler<DailyFeedQuery, DailyFeedQueryHandlerResult> handler, [FromBody] object request)
    {
        var result = await handler.HandleAsync(new DailyFeedQuery(), new CancellationToken());
        return result.DailyFeed;
    }

}
