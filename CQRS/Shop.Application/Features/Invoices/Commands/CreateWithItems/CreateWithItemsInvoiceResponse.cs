using Shop.Application.Features.InvoiceItems.Commands.Create;

namespace Shop.Application.Features.Invoices.Commands.CreateWithItems;

public class CreateWithItemsInvoiceResponse
{
    public CreateWithItemsInvoiceResponse()
    {
        InvoiceItems = new List<CreateInvoiceItemResponse>();
    }
    public Guid CustomerId { get; set; }

    public string CustomerFullName { get; set; } = "";

    public string Number { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public decimal DiscountedTotalPrice { get; set; }

    public string UsedDiscounts { get; set; } = "";

    public List<CreateInvoiceItemResponse> InvoiceItems { get; set; }
}


