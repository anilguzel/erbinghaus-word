using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;
using MongoDB.Driver;

namespace Ebbinghaus.Application.UseCases;

public class UpdateWordCommandHandler : ICommandHandler<UpdateWordCommand, UpdateWordCommandHandlerResult>
{
    private readonly IMongoContext _dbContext;

    public UpdateWordCommandHandler(IMongoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UpdateWordCommandHandlerResult> HandleAsync(UpdateWordCommand command, CancellationToken cancellationToken)
    {
        var word = await (await _dbContext.GetCollection<Word>().FindAsync(c=> c.id == command.Id)).FirstOrDefaultAsync();
        word.AddOrUpdate(command.Name, command.Id);
        var filter = Builders<Word>.Filter.Eq("id", command.Id);

        await _dbContext.GetCollection<Word>().ReplaceOneAsync(filter, word);
        return new UpdateWordCommandHandlerResult();
    }
}   