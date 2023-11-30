using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountCalculatorFactories.Base;
using Shop.Domain.Enum;
using Shop.Domain.MongoEntities;
using Shop.Domain.RelationalEntities;

namespace Shop.Application.Helpers.DiscountCalculatorFactories.Calculators;

public class PercentBasedDiscountCalculator : IDiscountCalculator
{
    public Invoice Calculate(Invoice invoice, ListDynamicDiscountResponse discount)
    {
        foreach (var item in invoice.InvoiceItems)
        {
            if (IsCategoryExcluded(item, discount))
                continue;

            decimal indirimMiktari = item.Price * discount.Value / 100;
            item.DiscountedPrice = item.Price - indirimMiktari;
            item.UsedDiscounts += $"{discount.Name}, ";
        }

        invoice.UsedDiscounts += $"{discount.Name}, ";
        invoice.DiscountedTotalPrice = invoice.InvoiceItems.Sum(x => x.DiscountedPrice);
        return invoice;
    }

    private bool IsCategoryExcluded(InvoiceItem invoiceItem, ListDynamicDiscountResponse discount)
    {
        return discount.Criteria.Any(w => w.DiscountAssignType == DiscountAssignType.ForExcludedCategory && w.Criterion == invoiceItem.CategoryId.ToString());
    }
}
