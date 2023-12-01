using Shop.Application.Extensions;
using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountFinderChain.Base;
using Shop.Domain.Enum;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountFinderChain.Chain;

public class ForRegisterBeforeYearDiscountHandler : AbstractDiscountFinder
{
    
    public override Invoice Handle(CalculateInvoiceDiscountCommand request, ListDynamicDiscountResponse discount)
    {
        var registerCriteria = discount.Criteria
     .Where(w => w.DiscountAssignType == DiscountAssignType.ForRegisterBeforeYear).Select(w => int.Parse(w.Criterion)).ToList();
        if (registerCriteria.IsNullOrEmpty() || DateTime.UtcNow >= request.CustomerInfo.CreatedTime.AddYears(registerCriteria.Max()))
            return base.Successor?.Handle(request, discount)?? request.Invoice;

        return request.Invoice;
    }
}
