using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class DiscountDal : EfRepositoryBase<Discount, Guid, ShopDbContext>, IDiscountDal
{
    public DiscountDal(ShopDbContext context) : base(context)
    {
    }
}
