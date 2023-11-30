using Core.CrossCuttingConcerns.Exceptions.Types;
using Shop.Application.Helpers.DiscountCalculatorFactories.Base;
using Shop.Application.Helpers.DiscountCalculatorFactories.Calculators;
using Shop.Domain.Enum;

namespace Shop.Application.Helpers.DiscountCalculatorFactories.Factory;

public class DiscountCalculatorFactory
{
    public IDiscountCalculator CreateInstance(DiscountUsageType type)
    {
        switch (type)
        {
            case DiscountUsageType.Percent:
                return new PercentBasedDiscountCalculator();
            case DiscountUsageType.Direct:
                return new DirectDiscountCalculator();
            default:
                throw new BusinessException($"IDiscountCalculator type {type} not found.");
        }

    }
}
