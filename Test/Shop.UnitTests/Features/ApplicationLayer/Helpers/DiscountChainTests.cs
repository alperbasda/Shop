using AutoFixture;
using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Features.Roles.Queries;
using Shop.Application.Helpers.DiscountFinderChain.Base;
using Shop.Application.Helpers.DiscountFinderChain.Chain;
using Shop.Domain.Enum;
using Shop.UnitTests.Base;

namespace Shop.UnitTests.Features.ApplicationLayer.Helpers;

public class DiscountChainTests : XUnitBase
{
    [Theory]
    [InlineData(100, 10, 90)]
    public void ForRoleDiscountHandler_WithMatchingRole_ReturnsExpectedPriceResult(decimal totalPrice, decimal discountRate, decimal expectedResult)
    {
        //Arrange
        var invoiceCustomerPoco = GeneratePoco<CalculateInvoiceDiscountCommand>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();
        var service = GenerateChainServices<ForRoleDiscountHandler>();

        //Act
        var roleId = Guid.NewGuid();
        invoiceCustomerPoco.CustomerInfo.Roles.Add(new GetByUserIdRoleResponse
        {
            Id = roleId,
            Name = "test"
        });
        invoiceCustomerPoco.Invoice.TotalPrice = totalPrice;
        var itemCount = invoiceCustomerPoco.Invoice.InvoiceItems.Count;
        invoiceCustomerPoco.Invoice.InvoiceItems.ForEach(x =>
        { x.Amount = 1; x.UnitPrice = (totalPrice / itemCount); x.Price = (totalPrice / itemCount); });

        invoiceCustomerPoco.Invoice.DiscountedTotalPrice = totalPrice;
        invoiceCustomerPoco.CustomerInfo.CreatedTime = DateTime.Now.AddYears(-3);
        discount.Criteria.ForEach(w => { w.DiscountAssignType = DiscountAssignType.ForRole; w.Criterion = roleId.ToString(); });
        discount.Value = discountRate;
        discount.DiscountUsageType = DiscountUsageType.Percent;
        var result = service.Handle(invoiceCustomerPoco, discount);

        //Assert
        Assert.Equal(expectedResult, result.DiscountedTotalPrice);
    }

    [Theory]
    [InlineData(100, 10, 90)]
    public void ForRegisterBeforeYearHandler_WithBeforeYear_ReturnsExpectedPriceResult(decimal totalPrice, decimal discountRate, decimal expectedResult)
    {
        //Arrange
        var invoiceCustomerPoco = Fixture.Create<CalculateInvoiceDiscountCommand>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();
        var service = GenerateChainServices<ForRegisterBeforeYearDiscountHandler>();

        //Act
        invoiceCustomerPoco.Invoice.TotalPrice = totalPrice;
        var itemCount = invoiceCustomerPoco.Invoice.InvoiceItems.Count;
        invoiceCustomerPoco.Invoice.InvoiceItems.ForEach(x =>
        { x.Amount = 1; x.UnitPrice = (totalPrice / itemCount); x.Price = (totalPrice / itemCount); });

        invoiceCustomerPoco.Invoice.DiscountedTotalPrice = totalPrice;
        invoiceCustomerPoco.CustomerInfo.CreatedTime = DateTime.Now.AddYears(-3);
        discount.Criteria.ForEach(w => { w.DiscountAssignType = DiscountAssignType.ForRegisterBeforeYear; w.Criterion = "2"; });
        discount.Value = discountRate;
        discount.DiscountUsageType = DiscountUsageType.Percent;
        var result = service.Handle(invoiceCustomerPoco, discount);

        //Assert

        Assert.Equal(expectedResult, result.DiscountedTotalPrice);
    }

    [Theory]
    [InlineData(500, 10, 450)]
    public void ForTotalPriceHandler_WithMinTotalPrice_ReturnsExpectedPriceResult(decimal totalPrice, decimal discountRate, decimal expectedResult)
    {
        //Arrange
        var invoiceCustomerPoco = Fixture.Create<CalculateInvoiceDiscountCommand>();
        var discount = GeneratePoco<ListDynamicDiscountResponse>();
        var service = GenerateChainServices<ForTotalPriceDiscountHandler>();

        //Act
        invoiceCustomerPoco.Invoice.TotalPrice = totalPrice;
        var itemCount = invoiceCustomerPoco.Invoice.InvoiceItems.Count;
        invoiceCustomerPoco.Invoice.InvoiceItems.ForEach(x =>
        { x.Amount = 1; x.UnitPrice = (totalPrice / itemCount); x.Price = (totalPrice / itemCount); });

        invoiceCustomerPoco.Invoice.DiscountedTotalPrice = totalPrice;
        invoiceCustomerPoco.CustomerInfo.CreatedTime = DateTime.Now.AddYears(-3);
        discount.Criteria.ForEach(w => { w.DiscountAssignType = DiscountAssignType.ForTotalPrice; w.Criterion = "100"; w.UseForDirectCondition = true; });
        discount.Value = discountRate;
        discount.DiscountUsageType = DiscountUsageType.Direct;
        var result = service.Handle(invoiceCustomerPoco, discount);

        //Assert

        Assert.Equal(expectedResult, result.DiscountedTotalPrice);
    }

    private AbstractDiscountFinder GenerateChainServices<T>()
    {
        List<AbstractDiscountFinder> instances = new List<AbstractDiscountFinder>();

        ForRoleDiscountHandler forRoleDiscountHandler = GenerateService<ForRoleDiscountHandler>();
        instances.Add(forRoleDiscountHandler);
        ForRegisterBeforeYearDiscountHandler forRegisterBeforeYearDiscountHandler = GenerateService<ForRegisterBeforeYearDiscountHandler>();
        instances.Add(forRegisterBeforeYearDiscountHandler);
        ForTotalPriceDiscountHandler forTotalPriceDiscountHandler = GenerateService<ForTotalPriceDiscountHandler>();
        instances.Add(forTotalPriceDiscountHandler);
        ChainBrokerHandler chainBrokerHandler = GenerateService<ChainBrokerHandler>();

        forRoleDiscountHandler.Successor = forRegisterBeforeYearDiscountHandler;
        forRegisterBeforeYearDiscountHandler.Successor = forTotalPriceDiscountHandler;
        forTotalPriceDiscountHandler.Successor = chainBrokerHandler;

        return instances.FirstOrDefault(w=> typeof(T) == w.GetType());
    }

}
