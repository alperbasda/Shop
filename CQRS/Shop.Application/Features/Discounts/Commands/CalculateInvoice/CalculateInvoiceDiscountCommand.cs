using MediatR;
using Shop.Application.Features.Customers.Queries.GetWithRolesById;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Features.Discounts.Commands.CalculateInvoice;

public class CalculateInvoiceDiscountCommand : IRequest<CalculateInvoiceDiscountResponse>
{
    public Invoice Invoice { get; set; }

    public GetWithRolesByIdCustomerResponse CustomerInfo { get; set; }
}
