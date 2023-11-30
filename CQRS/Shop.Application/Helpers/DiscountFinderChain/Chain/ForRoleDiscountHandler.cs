using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountFinderChain.Base;
using Shop.Domain.Enum;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountFinderChain.Chain;

public class ForRoleDiscountHandler : AbstractDiscountFinder
{
    public override Invoice Handle(CalculateInvoiceDiscountCommand request, ListDynamicDiscountResponse discount)
    {
        var containsSameElement = discount.Criteria
             .Where(w => w.DiscountAssignType == DiscountAssignType.ForRole).Select(w => Guid.Parse(w.Criterion))
             .All(request.CustomerInfo.Roles.Select(q => q.Id).Contains);
        if (containsSameElement)
            return base.Successor.Handle(request, discount);

        return request.Invoice;

    }
}
