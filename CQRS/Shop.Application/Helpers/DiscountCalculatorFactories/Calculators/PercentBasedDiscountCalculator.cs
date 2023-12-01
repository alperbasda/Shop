using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountCalculatorFactories.Base;
using Shop.Domain.Enum;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountCalculatorFactories.Calculators;

public class PercentBasedDiscountCalculator : IDiscountCalculator
{
    public Invoice Calculate(Invoice invoice, ListDynamicDiscountResponse discount)
    {
        bool applied = false;
        foreach (var item in invoice.InvoiceItems)
        {
            if (IsCategoryExcluded(item, discount))
                continue;

            applied = true;
            decimal discounted = item.Price * (discount.Value / 100);
            item.DiscountedPrice = item.Price - discounted;
            item.UsedDiscounts += $"{discount.Name}, ";
        }
        if (applied)
        {
            invoice.UsedDiscounts += $"{discount.Name}, ";
            invoice.DiscountedTotalPrice = invoice.InvoiceItems.Sum(x => x.DiscountedPrice);
        }
            
        return invoice;
    }

    private bool IsCategoryExcluded(InvoiceItem invoiceItem, ListDynamicDiscountResponse discount)
    {
        return discount.Criteria.Any(w => w.DiscountAssignType == DiscountAssignType.ForExcludedCategory && w.Criterion == invoiceItem.CategoryId.ToString());
    }
}
