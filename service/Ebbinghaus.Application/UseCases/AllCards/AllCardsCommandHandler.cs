using AutoMapper;
using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;

namespace Ebbinghaus.Application.UseCases;

public class AllCardsCommandHandler
        : ICommandHandler<AllCardsCommand, AllCardsCommandResult>
    {
        private readonly IMapper _mapper;
        public AllCardsCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<AllCardsCommandResult> HandleAsync(AllCardsCommand command, CancellationToken cancellationToken)
        {
            Guard.That(command == null, new ArgumentNullException(nameof(command)));

            return new AllCardsCommandResult();

        }
    }