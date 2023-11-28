using Microsoft.EntityFrameworkCore;
using Shop.Domain.Enum;
using Shop.Domain.RelationalEntities;

namespace Shop.Persistence.Contexts;

public class ShopDataInitilizer
{

    public static void InitData(ModelBuilder modelBuilder)
    {
        #region AddRoles
        var affiliateRoleId = Guid.NewGuid();
        var employeeRoleId = Guid.NewGuid();
        var standardRoleId = Guid.NewGuid();
        var roles = new[]
        {
            new Role
            {
                Id = employeeRoleId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "Employee"
            },
            new Role
            {
                Id = affiliateRoleId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "Affiliate"
            },
            new Role
            {
                Id = standardRoleId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "StardardAccount"
            },
        };

        modelBuilder.Entity<Role>().HasData(roles);
        #endregion

        #region AddDiscounts

        var percent30Discount = Guid.NewGuid();
        var percent10Discount = Guid.NewGuid();
        var percent5Discount = Guid.NewGuid();

        var discounts = new[]
        {
            new Discount
            {
                Id = percent30Discount,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "30% Discount",
                Value = 30,
                DiscountUsageType = DiscountUsageType.Percent
            },
            new Discount
            {
                Id = percent10Discount,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "10% Discount",
                Value = 10,
                DiscountUsageType = DiscountUsageType.Percent
            },
            new Discount
            {
                Id = percent5Discount,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "5% Discount If Over 2 Year",
                Value = 5,
                DiscountUsageType = DiscountUsageType.Percent
            },
            new Discount
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "$5 Discount For every $100",
                Value = 5,
                DiscountUsageType = DiscountUsageType.Direct
            }
        };

        modelBuilder.Entity<Discount>().HasData(discounts);

        #endregion

        #region AddDiscountRoles

        var discountRoles = new[]
        {
            new DiscountRoleRelation
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountId = percent30Discount,
                RoleId = employeeRoleId
            },
            new DiscountRoleRelation
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountId = percent10Discount,
                RoleId = affiliateRoleId
            }
        };

        modelBuilder.Entity<DiscountRoleRelation>().HasData(discountRoles);

        #endregion

        #region AddCustomer
        var affiliateCustomerId = Guid.NewGuid();
        var employeeCustomerId = Guid.NewGuid();
        var standardCustomerId = Guid.NewGuid();
        var customers = new[]
        {
            new Customer
            {
                Id = employeeCustomerId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                FirstName = "Employee",
                LastName = "Employee"
            },
            new Customer
            {
                Id = affiliateCustomerId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                FirstName = "Affiliate",
                LastName = "Affiliate"
            },
            new Customer
            {
                Id = standardCustomerId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                FirstName = "StardardAccount",
                LastName = "StardardAccount"
            },
        };

        modelBuilder.Entity<Customer>().HasData(customers);

        #endregion

        #region AddCustomerRoles

        var customerRoles = new[]
        {
            new CustomerRoleRelation
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CustomerId = employeeCustomerId,
                RoleId = employeeRoleId,
            },
            new CustomerRoleRelation
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CustomerId = affiliateCustomerId,
                RoleId = affiliateRoleId,
            },
            new CustomerRoleRelation
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CustomerId = standardCustomerId,
                RoleId = standardRoleId,
            },
        };

        modelBuilder.Entity<CustomerRoleRelation>().HasData(customerRoles);

        #endregion

        #region AddCategories

        var groceryCategoryId = Guid.NewGuid();
        var fruitCategoryId = Guid.NewGuid();
        var meatCategoryId = Guid.NewGuid();
        var categories = new[]
        {
            new Category
            {
                Id = groceryCategoryId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "Grocery"
            },
            new Category
            {
                Id = fruitCategoryId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "Fruits & Vegatables"
            },
            new Category
            {
                Id = meatCategoryId,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "Meat & Fish"
            },
        };

        modelBuilder.Entity<Category>().HasData(categories);

        #endregion

        #region AddExcludedCategoryDiscountRelations

        var excludedCategoryDiscounts = discounts.Where(q => q.DiscountUsageType == DiscountUsageType.Percent).Select(q => new ExcludedCategoryDiscount
        {
            Id = Guid.NewGuid(),
            CreatedTime = DateTime.Now,
            DeletedTime = null,
            UpdatedTime = null,
            CategoryId = groceryCategoryId,
            DiscountId = q.Id,
        }).ToArray();

        modelBuilder.Entity<ExcludedCategoryDiscount>().HasData(excludedCategoryDiscounts);

        #endregion

        #region AddProducts

        var products = new[]
        {
            new Product
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CategoryId = meatCategoryId,
                Name = "Beef"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CategoryId = fruitCategoryId,
                Name = "Banana"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CategoryId = groceryCategoryId,
                Name = "Cigarette"
            },
        };

        modelBuilder.Entity<Product>().HasData(products);

        #endregion
    }


}
