using MediatR;
using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Discounts.Queries.ListDynamic;
using Shop.Application.Helpers.DiscountFinderChain.Base;

namespace Shop.Application.Features.Discounts.Handlers.Commands.CalculateInvoice;

public class CalculateInvoiceDiscountCommandHandler : IRequestHandler<CalculateInvoiceDiscountCommand, CalculateInvoiceDiscountResponse>
{
    private readonly IDiscountChainStarter _discountChainStarter;
    private readonly IMediator _mediator;
    public CalculateInvoiceDiscountCommandHandler(IDiscountChainStarter discountChainStarter, IMediator mediator)
    {
        _discountChainStarter = discountChainStarter;
        _mediator = mediator;
    }

    public async Task<CalculateInvoiceDiscountResponse> Handle(CalculateInvoiceDiscountCommand request, CancellationToken cancellationToken)
    {
        var cacheDiscounts = (await _mediator.Send(new ListDynamicDiscountQuery(), cancellationToken: cancellationToken)).Items.OrderBy(q => q.Priority);
        foreach (var discount in cacheDiscounts)
        {
            if (request.Invoice.DiscountedTotalPrice != request.Invoice.TotalPrice)
                break;
            _discountChainStarter.Start(request, discount);
        }
        return new CalculateInvoiceDiscountResponse
        {
            Invoice = request.Invoice
        };

    }
}
