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
public class WordController : ControllerBase
{
    [HttpPost]
    public async Task<CreateWordCommandHandlerResult> Create([FromServices] ICommandHandler<CreateWordCommand, CreateWordCommandHandlerResult> handler,
    [FromBody] CreateWordRequest request)
    {
        var result = await handler.HandleAsync(new CreateWordCommand(request.Name, request.CardId), new CancellationToken());
        return result;
    }

    [HttpPut]
    public async Task<UpdateWordCommandHandlerResult> Update([FromServices] ICommandHandler<UpdateWordCommand, UpdateWordCommandHandlerResult> handler,
    [FromBody] UpdateWordRequest request)
    {
        var result = await handler.HandleAsync(new UpdateWordCommand(request.CardId, request.Id, request.Name), new CancellationToken());
        return result;
    }
    
    [HttpPost("sentence")]
    public async Task<CreateWordSentenceCommandHandlerResult> CreateSentence([FromServices] ICommandHandler<CreateWordSentenceCommand, CreateWordSentenceCommandHandlerResult> handler,
    [FromBody] CreateWordSentenceRequest request)
    {
        var result = await handler.HandleAsync(new CreateWordSentenceCommand(request.WordId, request.Text), new CancellationToken());
        return result;
    }

    [HttpPut("sentence")]
    public async Task<UpdateWordSentenceCommandHandlerResult> UpdateSentence([FromServices] ICommandHandler<UpdateWordSentenceCommand, UpdateWordSentenceCommandHandlerResult> handler,
    [FromBody] UpdateWordSentenceRequest request)
    {
        var result = await handler.HandleAsync(new UpdateWordSentenceCommand(request.WordId, request.SentenceId, request.Text), new CancellationToken());
        return result;
    }
}
