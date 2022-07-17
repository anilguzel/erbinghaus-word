using Microsoft.Extensions.DependencyInjection;
using Ebbinghaus.Framework;
using Ebbinghaus.Domain.Commands;
using Ebbinghaus.Application.UseCases;

namespace Ebbinghaus.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApp(this IServiceCollection services)
        {
            return services
                .SetupCommandHandler();
        }

        private static IServiceCollection SetupCommandHandler(this IServiceCollection services)
        {
            services.AddSingleton<ICommandHandler<CreateWordCommand, CreateWordCommandHandlerResult>, CreateWordCommandHandler>();
            services.AddSingleton<ICommandHandler<UpdateWordCommand, UpdateWordCommandHandlerResult>, UpdateWordCommandHandler>();
            services.AddSingleton<ICommandHandler<CreateWordSentenceCommand, CreateWordSentenceCommandHandlerResult>, CreateWordSentenceCommandHandler>();
            services.AddSingleton<ICommandHandler<UpdateWordSentenceCommand, UpdateWordSentenceCommandHandlerResult>, UpdateWordSentenceCommandHandler>();
            services.AddSingleton<IQueryHandler<DailyFeedQuery, DailyFeedQueryHandlerResult>, DailyFeedQueryHandler>();
            return services;
        }
    }
}