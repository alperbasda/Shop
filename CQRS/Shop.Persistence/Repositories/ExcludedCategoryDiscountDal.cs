using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class ExcludedCategoryDiscountDal : EfRepositoryBase<ExcludedCategoryDiscount, Guid, ShopDbContext>, IExcludedCategoryDiscountDal
{
    public ExcludedCategoryDiscountDal(ShopDbContext context) : base(context)
    {
    }
}
