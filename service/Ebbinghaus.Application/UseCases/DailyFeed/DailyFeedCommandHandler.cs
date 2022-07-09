using AutoMapper;
using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;


namespace Ebbinghaus.Application.UseCases;

public class DailyFeedCommandHandler:ICommandHandler<DailyFeedCommand, DailyFeedCommandResult>
    {
        private readonly IMapper _mapper;
        public DailyFeedCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<DailyFeedCommandResult> HandleAsync(DailyFeedCommand command, CancellationToken cancellationToken)
        {
            Guard.That(command == null, new ArgumentNullException(nameof(command)));

            return new DailyFeedCommandResult();
        }
    }