using AutoMapper;
using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Framework;

namespace Ebbinghaus.Application.UseCases;

public class AllCardsCommandHandler
        : ICommandHandler<AllCardsCommand, AllCardsCommandHandlerResult>
    {
        public async Task<AllCardsCommandHandlerResult> HandleAsync(AllCardsCommand command, CancellationToken cancellationToken)
        {
            Guard.That(command == null, new ArgumentNullException(nameof(command)));

            return new AllCardsCommandHandlerResult();

        }
    }