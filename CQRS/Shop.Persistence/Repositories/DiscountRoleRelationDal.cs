using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class DiscountRoleRelationDal : EfRepositoryBase<DiscountRoleRelation, Guid, ShopDbContext>, IDiscountRoleRelationDal
{
    public DiscountRoleRelationDal(ShopDbContext context) : base(context)
    {
    }
}
