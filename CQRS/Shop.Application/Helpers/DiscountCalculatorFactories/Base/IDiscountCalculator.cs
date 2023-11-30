using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountCalculatorFactories.Base;

public interface IDiscountCalculator
{
    Invoice Calculate(Invoice invoice, ListDynamicDiscountResponse discount);
}
