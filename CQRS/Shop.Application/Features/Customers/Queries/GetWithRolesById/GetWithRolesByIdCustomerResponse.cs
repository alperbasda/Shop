using Shop.Application.Features.Roles.Queries;

namespace Shop.Application.Features.Customers.Queries.GetWithRolesById;

public class GetWithRolesByIdCustomerResponse
{
    public GetWithRolesByIdCustomerResponse()
    {
        Roles = new List<GetByUserIdRoleResponse>();
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public List<GetByUserIdRoleResponse> Roles { get; set; }
}
