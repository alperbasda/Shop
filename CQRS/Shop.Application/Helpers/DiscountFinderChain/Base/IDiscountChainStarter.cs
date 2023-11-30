using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Domain.MongoEntities;
using Shop.Domain.RelationalEntities;

namespace Shop.Application.Helpers.DiscountFinderChain.Base;

public interface IDiscountChainStarter
{
    Invoice Start(CalculateInvoiceDiscountCommand request, ListDynamicDiscountResponse discount);
}
