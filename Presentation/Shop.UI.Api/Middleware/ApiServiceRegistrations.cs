using Core.ApiHelpers.JwtHelper.Models;
using Core.CrossCuttingConcerns.Serilog;
using Core.CrossCuttingConcerns.Serilog.Logger;
using Shop.Application;
using Shop.Persistence;

namespace Shop.UI.Api.Middleware;

public static class ApiServiceRegistrations
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddHttpContextAccessor();
        //services.AddTransient<LoggerServiceBase, ElasticLogger>();
        //services.AddScoped<TokenParameters>();
        //services.AddApplicationServices(configuration);
        services.AddPersistenceServices(configuration);

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
