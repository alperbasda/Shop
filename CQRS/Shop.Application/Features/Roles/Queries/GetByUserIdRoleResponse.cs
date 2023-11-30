namespace Shop.Application.Features.Roles.Queries;

public class GetByUserIdRoleResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
