using Shop.Application.Extensions;
using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountFinderChain.Base;
using Shop.Domain.Enum;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountFinderChain.Chain;

public class ForTotalPriceDiscountHandler : AbstractDiscountFinder
{
    public ForTotalPriceDiscountHandler()
    {

    }
    public override Invoice Handle(CalculateInvoiceDiscountCommand request, ListDynamicDiscountResponse discount)
    {
        var totalPriceCriteria = discount.Criteria
     .Where(w => w.DiscountAssignType == DiscountAssignType.ForTotalPrice).Select(w => decimal.Parse(w.Criterion)).ToList();
        if (totalPriceCriteria.IsNullOrEmpty() || totalPriceCriteria.Max() <= request.Invoice.TotalPrice)
            return base.Successor.Handle(request, discount);

        return request.Invoice;
    }
}
