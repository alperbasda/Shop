using MediatR;

namespace Shop.Application.Features.Customers.Queries.GetWithRolesById;

public class GetWithRolesByIdCustomerQuery : IRequest<GetWithRolesByIdCustomerResponse>
{
    public Guid Id { get; set; }
}
