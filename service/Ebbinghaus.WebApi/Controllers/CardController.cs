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

    [HttpGet("feed")]
    public async Task<DailyFeedContract> DailyFeedAsync([FromServices] IQueryHandler<DailyFeedQuery, DailyFeedQueryHandlerResult> handler)
    {
        var result = await handler.HandleAsync(new DailyFeedQuery(), new CancellationToken());
        return result.DailyFeed;
    }
}
