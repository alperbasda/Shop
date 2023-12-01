namespace Shop.Application.Features.InvoiceItems.Commands.Create;

public class CreateInvoiceItemResponse
{
    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public decimal DiscountedPrice { get; set; }

    public string UsedDiscounts { get; set; } = "";
}
