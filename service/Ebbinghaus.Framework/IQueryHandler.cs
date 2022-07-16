using System.Threading;
using System.Threading.Tasks;

namespace Ebbinghaus.Framework
{
    public interface IQueryHandler<TQuery,TResult>
        where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}