using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;
using MongoDB.Driver;

namespace Ebbinghaus.Application.UseCases;

public class UpdateWordSentenceCommandHandler : ICommandHandler<UpdateWordSentenceCommand, UpdateWordSentenceCommandHandlerResult>
{
    private readonly IMongoContext _dbContext;

    public UpdateWordSentenceCommandHandler(IMongoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UpdateWordSentenceCommandHandlerResult> HandleAsync(UpdateWordSentenceCommand command, CancellationToken cancellationToken)
    {
        var word = await (await _dbContext.GetCollection<Word>().FindAsync(c => c.id == command.WordId)).FirstOrDefaultAsync();
        word.UpdateSentence(command.Text, command.SentenceId);

        var filter = Builders<Word>.Filter.Eq("id", command.WordId);
        await _dbContext.GetCollection<Word>().ReplaceOneAsync(filter, word);

        return new UpdateWordSentenceCommandHandlerResult();
    }
}