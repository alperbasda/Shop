using MediatR;

namespace Shop.Application.Features.InvoiceItems.Commands.Create;

public class CreateInvoiceItemCommand : IRequest<CreateInvoiceItemResponse>
{
    public Guid ProductId { get; set; }

    public int Amount { get; set; }
}
