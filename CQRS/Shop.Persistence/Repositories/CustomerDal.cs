using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class CustomerDal : EfRepositoryBase<Customer, Guid, ShopDbContext>, ICustomerDal
{
    public CustomerDal(ShopDbContext context) : base(context)
    {
    }
}
