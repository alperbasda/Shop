using Microsoft.EntityFrameworkCore;
using Shop.Domain.RelationalEntities;
using System.Reflection;

namespace Shop.Persistence.Contexts;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerRoleRelation> CustomerRoleRelations { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountRoleRelation> DiscountRoleRelations { get; set; }

    public virtual DbSet<ExcludedCategoryDiscount> ExcludedCategoryDiscounts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema("shop");
    }
}
