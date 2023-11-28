using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class RoleDal : EfRepositoryBase<Role, Guid, ShopDbContext>, IRoleDal
{
    public RoleDal(ShopDbContext context) : base(context)
    {
    }
}
