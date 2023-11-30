using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountFinderChain.Base;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountFinderChain.Chain;

public class ChainBrokerHandler : AbstractDiscountFinder
{
    public override Invoice Handle(CalculateInvoiceDiscountCommand request, ListDynamicDiscountResponse discount)
    {
        return base.CalculateDiscount(request.Invoice, discount);
    }
}
