using Core.Persistence.Dynamic;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Enum;
using Shop.Domain.RelationalEntities;

namespace Shop.Persistence.Contexts;

public class ShopDataInitilizer
{
    protected ShopDataInitilizer()
    {
        
    }

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
        var direct5Discount = Guid.NewGuid();

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
                DiscountUsageType = DiscountUsageType.Percent,
                Priority = 1,
                
            },
            new Discount
            {
                Id = percent10Discount,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "10% Discount",
                Value = 10,
                DiscountUsageType = DiscountUsageType.Percent,
                Priority = 2,
                
            },
            new Discount
            {
                Id = percent5Discount,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "5% Discount If Over 2 Year",
                Value = 5,
                DiscountUsageType = DiscountUsageType.Percent,
                Priority = 3,
                
            },
            new Discount
            {
                Id = direct5Discount,
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                Name = "5 Discount For every 100",
                Value = 5,
                DiscountUsageType = DiscountUsageType.Direct,
                Priority = 4
            }
        };

        modelBuilder.Entity<Discount>().HasData(discounts);

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

        #region AddDiscountCriteria

        var discountCriteria = new[]
        {
            new DiscountCriterion
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountAssignType = DiscountAssignType.ForRole,
                DiscountId = percent30Discount,
                Criterion = employeeRoleId.ToString(),
            },
            new DiscountCriterion
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountAssignType = DiscountAssignType.ForRole,
                DiscountId = percent10Discount,
                Criterion = affiliateRoleId.ToString(),
            },
            new DiscountCriterion
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountAssignType = DiscountAssignType.ForRegisterBeforeYear,
                DiscountId = percent5Discount,
                Criterion = "2".ToString(),
            },
            new DiscountCriterion
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountAssignType = DiscountAssignType.ForTotalPrice,
                DiscountId = direct5Discount,
                Criterion = "100".ToString(),
                UseForDirectCondition = true,
            },
            new DiscountCriterion
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountAssignType = DiscountAssignType.ForExcludedCategory,
                DiscountId = percent5Discount,
                Criterion = groceryCategoryId.ToString(),
            },
            new DiscountCriterion
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountAssignType = DiscountAssignType.ForExcludedCategory,
                DiscountId = percent10Discount,
                Criterion = groceryCategoryId.ToString(),
            },
            new DiscountCriterion
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                DiscountAssignType = DiscountAssignType.ForExcludedCategory,
                DiscountId = percent30Discount,
                Criterion = groceryCategoryId.ToString(),
            },
        };

        modelBuilder.Entity<DiscountCriterion>().HasData(discountCriteria);

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
                Name = "Beef",
                UnitPrice = 100
            },
            new Product
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CategoryId = fruitCategoryId,
                Name = "Banana",
                UnitPrice = 20
            },
            new Product
            {
                Id = Guid.NewGuid(),
                CreatedTime = DateTime.Now,
                DeletedTime = null,
                UpdatedTime = null,
                CategoryId = groceryCategoryId,
                Name = "Cigarette",
                UnitPrice = 50
            },
        };

        modelBuilder.Entity<Product>().HasData(products);

        #endregion
    }


}
