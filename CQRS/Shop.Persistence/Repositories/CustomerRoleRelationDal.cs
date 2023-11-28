using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class CustomerRoleRelationDal : EfRepositoryBase<CustomerRoleRelation, Guid, ShopDbContext>, ICustomerRoleRelationDal
{
    public CustomerRoleRelationDal(ShopDbContext context) : base(context)
    {
    }
}
