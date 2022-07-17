using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;
using MongoDB.Driver;

namespace Ebbinghaus.Application.UseCases;

public class CreateWordSentenceCommandHandler : ICommandHandler<CreateWordSentenceCommand, CreateWordSentenceCommandHandlerResult>
{
    private readonly IMongoContext _dbContext;

    public CreateWordSentenceCommandHandler(IMongoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateWordSentenceCommandHandlerResult> HandleAsync(CreateWordSentenceCommand command, CancellationToken cancellationToken)
    {
        var word = await (await _dbContext.GetCollection<Word>().FindAsync(c=> c.id == command.WordId)).FirstOrDefaultAsync();
        word.AddSentence(command.Text);

        var filter = Builders<Word>.Filter.Eq("id", command.WordId);
        await _dbContext.GetCollection<Word>().ReplaceOneAsync(filter, word);

        return new CreateWordSentenceCommandHandlerResult();
    }
}