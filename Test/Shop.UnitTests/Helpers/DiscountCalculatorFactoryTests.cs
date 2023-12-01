using Core.CrossCuttingConcerns.Exceptions.Types;
using Moq;
using Shop.Application.Features.DiscountCriterias.Queries.ListDynamic;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountCalculatorFactories.Calculators;
using Shop.Application.Helpers.DiscountCalculatorFactories.Factory;
using Shop.Domain.Enum;
using Shop.Domain.MongoEntities;
using Shop.UnitTests.Base;

namespace Shop.UnitTests.Helpers;

public class DiscountCalculatorFactoryTests : XUnitBase
{
    [Theory]
    [InlineData(DiscountUsageType.Percent, typeof(PercentBasedDiscountCalculator))]
    [InlineData(DiscountUsageType.Direct, typeof(DirectDiscountCalculator))]
    public void GetInstance_When_DiscountUsageTypeValid(DiscountUsageType type, Type expectedClassType)
    {
        //Arrange
        var service = GenerateService<DiscountCalculatorFactory>();

        //Act
        var result = service.CreateInstance(type);

        //Assert
        Assert.IsType(expectedClassType, result);

    }

    [Fact]
    public void DoNotChangeDiscountedPrice_When_InvoiceItemProductInExcludedCategory()
    {
        //Arrange
        var invoice = GeneratePoco<Invoice>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();

        var excludedCategoryId = Guid.NewGuid();


        var service = GenerateService<PercentBasedDiscountCalculator>();

        //Act
        var totalPrice = 10000;
        invoice.DiscountedTotalPrice = totalPrice;
        invoice.TotalPrice = invoice.DiscountedTotalPrice;
        invoice.InvoiceItems.ForEach(w => { w.CategoryId = excludedCategoryId; });
        discount.Criteria.ForEach(w => { w.DiscountAssignType = DiscountAssignType.ForExcludedCategory; w.Criterion = excludedCategoryId.ToString(); });
        var result = service.Calculate(invoice, discount);

        //Assert
        Assert.Equal(totalPrice, result.DiscountedTotalPrice);

    }

    [Theory]
    [InlineData(10)]
    public void ApplyDiscount_When_InvoiceItemProductNotInExcludedCategory(decimal discountRate)
    {
        //Arrange
        var invoice = GeneratePoco<Invoice>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();


        var service = GenerateService<PercentBasedDiscountCalculator>();

        //Act
        invoice.TotalPrice = invoice.InvoiceItems.Sum(q => q.Price);
        discount.Value = discountRate;
        var result = service.Calculate(invoice, discount);
        decimal discounted = invoice.TotalPrice * discount.Value / 100;
        var expectedResult = invoice.TotalPrice - discounted;

        //Assert
        Assert.Equal(expectedResult, result.DiscountedTotalPrice);

    }

    [Fact]
    public void ThrowBusinessException_When_UseForDirectConditionFlagIsFalseForAllRecord()
    {
        //Arrange
        var invoice = GeneratePoco<Invoice>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();

        var excludedCategoryId = Guid.NewGuid();


        var service = GenerateService<DirectDiscountCalculator>();

        //Act
        discount.Criteria.ForEach(w => { w.UseForDirectCondition = false; w.Criterion = It.IsAny<int>().ToString(); });

        //Assert & Act
        Assert.Throws<BusinessException>(() => service.Calculate(invoice, discount));

    }

    [Fact]
    public void ThrowBusinessException_When_TotalPriceLessThanOrEqualsZero()
    {
        //Arrange
        var invoice = GeneratePoco<Invoice>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();

        var excludedCategoryId = Guid.NewGuid();


        var service = GenerateService<DirectDiscountCalculator>();

        //Act
        invoice.TotalPrice = 0;
        discount.Criteria.ForEach(w => { w.UseForDirectCondition = true; w.Criterion = It.IsAny<int>().ToString(); });

        //Assert & Act
        Assert.Throws<BusinessException>(() => service.Calculate(invoice, discount));

    }

    [Fact]
    public void ApplyDiscount_When_DiscountConditionsApproved()
    {
        //Arrange
        var invoice = GeneratePoco<Invoice>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();

        var excludedCategoryId = Guid.NewGuid();


        var service = GenerateService<DirectDiscountCalculator>();

        //Act
        invoice.TotalPrice = 200;
        discount.Value = 20;
        discount.Criteria.ForEach(w => { w.UseForDirectCondition = true; w.Criterion = "5".ToString(); });

        //Assert & Act
        Assert.NotEqual(invoice.TotalPrice, invoice.DiscountedTotalPrice);

    }
}
