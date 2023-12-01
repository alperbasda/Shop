using MediatR;
using Shop.Application.Features.InvoiceItems.Commands.Create;

namespace Shop.Application.Features.Invoices.Commands.CreateWithItems;

public class CreateWithItemsInvoiceCommand : IRequest<CreateWithItemsInvoiceResponse>
{
    public CreateWithItemsInvoiceCommand()
    {
        InvoiceItems = new List<CreateInvoiceItemCommand>();
    }
    public Guid CustomerId { get; set; }

    public List<CreateInvoiceItemCommand> InvoiceItems { get; set; }
}
