using Shop.Domain.MongoEntities;
using Shop.Application.Helpers.DiscountCalculatorFactories.Factory;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Features.Discounts.Commands.CalculateInvoice;

namespace Shop.Application.Helpers.DiscountFinderChain.Base;

public abstract class AbstractDiscountFinder
{
    public AbstractDiscountFinder Successor { get; set; }

    private DiscountCalculatorFactory _factory;
    public AbstractDiscountFinder()
    {
        _factory = new DiscountCalculatorFactory();
    }

    public abstract Invoice Handle(CalculateInvoiceDiscountCommand request, ListDynamicDiscountResponse discount);

    protected Invoice CalculateDiscount(Invoice invoice, ListDynamicDiscountResponse discount)
    {
        var calculator = _factory.CreateInstance(discount.DiscountUsageType);
        
        return calculator.Calculate(invoice, discount);
    }
}
