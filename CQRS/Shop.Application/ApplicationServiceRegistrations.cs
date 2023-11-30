using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Base;
using Shop.Application.Helpers.DiscountFinderChain.Base;
using StackExchange.Redis;
using System.Reflection;

namespace Shop.Application;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var execAssembly = Assembly.GetExecutingAssembly();
        var cacheSettings = services.AddSettingsSingleton<CacheSettings>(configuration);


        services.AddSubClassesOfType(execAssembly, typeof(BaseBusinessRules));
        services.AddAutoMapper(execAssembly);
        services.AddValidatorsFromAssembly(execAssembly);
        services.AddRedis(cacheSettings);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(execAssembly);
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));

            ///Dikkat.Aynı anda dbye erişmesi gereken işlemlerde publish kullanırsan ef core concurrency fırlatır.
            configuration.NotificationPublisher = new TaskWhenAllPublisher();
            configuration.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            configuration.Lifetime = ServiceLifetime.Scoped;
        });

        

        services.AddScoped<IDiscountChainStarter, DiscountChainStarter>();


        return services;
    }

    public static void AddRedis(this IServiceCollection services, CacheSettings cacheSettings)
    {
        if (!cacheSettings.IsActive)
            return;

        services.AddDistributedMemoryCache();
        services.AddStackExchangeRedisCache(opt =>
        {

            opt.ConfigurationOptions = new ConfigurationOptions
            {
                Password = cacheSettings.Password,
                EndPoints =
                    {
                        { cacheSettings.Host, int.Parse(cacheSettings.Port) }
                    },
            };
        });
    }

    public static IServiceCollection AddSubClassesOfType(
       this IServiceCollection services,
       Assembly assembly,
       Type type,
       Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }

    public static T AddSettingsSingleton<T>(this IServiceCollection services, IConfiguration configuration)
    where T : class, new()
    {
        T settings = new T();
        configuration.GetSection(settings.GetType().Name).Bind(settings);

        services.Configure<T>(options =>
        {
            options = settings;
        });
        services.AddSingleton<T>(sp =>
        {
            return settings;
        });
        return settings;
    }
}
