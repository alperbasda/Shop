using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountFinderChain.Chain;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Helpers.DiscountFinderChain.Base;

public class DiscountChainStarter : IDiscountChainStarter
{
    public Invoice Start(CalculateInvoiceDiscountCommand request, ListDynamicDiscountResponse discount)
    {
        ForRoleDiscountHandler forRoleDiscountHandler = new ForRoleDiscountHandler();
        ForRegisterBeforeYearDiscountHandler forRegisterBeforeYearDiscountHandler = new ForRegisterBeforeYearDiscountHandler();
        ForTotalPriceDiscountHandler forTotalPriceDiscountHandler = new ForTotalPriceDiscountHandler();
        ChainBrokerHandler chainBrokerHandler = new ChainBrokerHandler();

        forRoleDiscountHandler.Successor = forRegisterBeforeYearDiscountHandler;
        forRegisterBeforeYearDiscountHandler.Successor = forTotalPriceDiscountHandler;
        forTotalPriceDiscountHandler.Successor = chainBrokerHandler;

        return forRoleDiscountHandler.Handle(request, discount);
    }
}
