using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;
using MongoDB.Driver;

namespace Ebbinghaus.Application.UseCases;

public class DailyFeedQueryHandler : IQueryHandler<DailyFeedQuery, DailyFeedQueryHandlerResult>
{
    private readonly IMongoContext _dbContext;

    public DailyFeedQueryHandler(IMongoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DailyFeedQueryHandlerResult> HandleAsync(DailyFeedQuery query, CancellationToken cancellationToken)
    {
        Guard.That(query == null, new ArgumentNullException(nameof(query)));

        var result = (await _dbContext.GetCollection<Word>().FindAsync(c=> !c.is_done)).ToList();
        
        if(result == null)
            throw new Exception();

        return new DailyFeedQueryHandlerResult{
            DailyFeed = new Contracts.DailyFeedContract {
                Words = result
            }
        };
    }
}