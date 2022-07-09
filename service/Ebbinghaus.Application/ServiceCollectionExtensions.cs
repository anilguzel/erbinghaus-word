using Microsoft.Extensions.DependencyInjection;
using Ebbinghaus.Framework;
using Ebbinghaus.Domain.Commands;
using AutoMapper;
using Ebbinghaus.Application.UseCases;

namespace Alakazam.Basket.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection SetupApp(this IServiceCollection services)
        {
            return services
                .SetupCommandHandler();
                // .SetupMappings();
        }

        private static IServiceCollection SetupCommandHandler(this IServiceCollection services)
        {
            services.AddSingleton<ICommandHandler<AllCardsCommand, AllCardsCommandResult>, AllCardsCommandHandler>();
            services.AddSingleton<ICommandHandler<DailyFeedCommand, DailyFeedCommandResult>, DailyFeedCommandHandler>();
            return services;
        }

        // private static IServiceCollection SetupMappings(this IServiceCollection services)
        // {
        //     return services.AddAutoMapper(cfg =>{
        //         cfg.AddProfile<BasketContractProfile>();
        //     });
        // }
    }
}