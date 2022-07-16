using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupInfra(this IServiceCollection services)
    {
        return services
            .SetupRepository()
            .SetupAdaptor();
    }
    private static IServiceCollection SetupAdaptor(this IServiceCollection services)
    {
        return services;
    }
    private static IServiceCollection SetupRepository(this IServiceCollection services)
    {
        // services.AddSingleton<IBasketCommandRepository, BasketInMemoryCommandRepository>();
        // services.AddSingleton<IBasketQueryRepository, BasketInMemoryQueryRepository>();
        services.AddSingleton<IMongoContext, AppMongoContext>();
        return services;
    }
}