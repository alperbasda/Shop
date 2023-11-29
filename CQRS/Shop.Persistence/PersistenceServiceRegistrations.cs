
using Core.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Contracts.Repositories;
using Shop.Persistence.Contexts;
using Shop.Persistence.Repositories;

namespace Shop.Persistence;

public static class PersistenceServiceRegistrations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseOptions = services.AddSettingsSingleton<DatabaseOptions>(configuration);
        services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(databaseOptions.EfConnectionString));

        services.AddScoped<ICategoryDal, CategoryDal>();
        services.AddScoped<ICustomerDal, CustomerDal>();
        services.AddScoped<ICustomerRoleRelationDal, CustomerRoleRelationDal>();
        services.AddScoped<IDiscountDal, DiscountDal>();
        services.AddScoped<IDiscountCriterionDal, DiscountCriterionDal>();
        services.AddScoped<IInvoiceDal, InvoiceDal>();
        services.AddScoped<IInvoiceItemDal, InvoiceItemDal>();
        services.AddScoped<IProductDal, ProductDal>();
        services.AddScoped<IRoleDal, RoleDal>();

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
        services.AddSingleton(sp =>
        {
            return settings;
        });
        return settings;
    }
}
