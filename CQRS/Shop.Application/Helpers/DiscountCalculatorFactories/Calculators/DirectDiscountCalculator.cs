using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountCalculatorFactories.Base;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountCalculatorFactories.Calculators;

public class DirectDiscountCalculator : IDiscountCalculator
{
    public Invoice Calculate(Invoice invoice, ListDynamicDiscountResponse discount)
    {
        var conditionCriterion = discount.Criteria.Where(w =>
        {
            if (!w.UseForDirectCondition)
                return false;

            if (int.TryParse(w.Criterion, out int criterionAsInt) && criterionAsInt > 0)
            {
                return true;
            }
            return false;
        }).Select(q => int.Parse(q.Criterion)).ToList();

        if (conditionCriterion.IsNullOrEmpty())
        {
            throw new BusinessException("Direct tipindeki indirimlerin UseForDirectCondition değeri true ayarlanmalıdır. ");
        }
        if (invoice.TotalPrice <= 0)
        {
            throw new BusinessException("Fatura tutarı 0'dan büyük olmalı. ");
        }
        var multiplexer = Math.Floor(invoice.TotalPrice / conditionCriterion.Max());

        if (multiplexer > 0)
        {
            invoice.DiscountedTotalPrice = invoice.TotalPrice - (multiplexer * discount.Value);
            invoice.UsedDiscounts += $"{discount.Name}, ";
        }

        return invoice;
    }
}
