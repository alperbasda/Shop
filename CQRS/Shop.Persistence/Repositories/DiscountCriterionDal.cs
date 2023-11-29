using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class DiscountCriterionDal : EfRepositoryBase<DiscountCriterion, Guid, ShopDbContext>, IDiscountCriterionDal
{
    public DiscountCriterionDal(ShopDbContext context) : base(context)
    {
    }
}
