using MediatR;
using Shop.Application.Base;
using Shop.Application.Features.Customers.Queries.GetWithRolesById;
using Shop.Application.Features.InvoiceItems.Commands.Create;
using Shop.Application.Features.Products.Queries.ListByIds;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Features.Invoices.Rules;

public class InvoiceBusinessRules : BaseBusinessRules
{
    IMediator _mediator;
    public InvoiceBusinessRules(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task<GetWithRolesByIdCustomerResponse> GetCustomerInfo(Guid customerId)
    {
        return await _mediator.Send(new GetWithRolesByIdCustomerQuery { Id = customerId });
    }

    public async Task<List<ListByIdsProductResponse>> GetProducts(List<Guid> ids)
    {
        return await _mediator.Send(new ListByIdsProductQuery { Ids = ids });
    }

    public List<InvoiceItem> CreateInvoiceItems(List<ListByIdsProductResponse> products, List<CreateInvoiceItemCommand> invoiceItems)
    {
        List<InvoiceItem> returnList = new List<InvoiceItem>();
        foreach (var item in invoiceItems)
        {
            var selectedProduct = products.First(w => w.Id == item.ProductId);
            returnList.Add(new InvoiceItem
            {
                Id = Guid.NewGuid(),
                ProductName = selectedProduct.Name,
                Amount = item.Amount,
                UnitPrice = selectedProduct.UnitPrice,
                Price = item.Amount * selectedProduct.UnitPrice,
                CategoryId = selectedProduct.CategoryId,
                ProductId = selectedProduct.Id,
                DiscountedPrice = selectedProduct.UnitPrice,
            });
        }

        return returnList;
    }

}
