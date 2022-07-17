using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;
using MongoDB.Driver;

namespace Ebbinghaus.Application.UseCases;

public class CreateWordCommandHandler : ICommandHandler<CreateWordCommand, CreateWordCommandHandlerResult>
{
    private readonly IMongoContext _dbContext;

    public CreateWordCommandHandler(IMongoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateWordCommandHandlerResult> HandleAsync(CreateWordCommand command, CancellationToken cancellationToken)
    {
        var word = new Word();
        word.AddOrUpdate(command.Name, word.id);
        await _dbContext.GetCollection<Word>().InsertOneAsync(word);

        return new CreateWordCommandHandlerResult();
    }
}