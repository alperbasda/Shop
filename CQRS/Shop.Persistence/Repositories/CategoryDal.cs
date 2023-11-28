using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class CategoryDal : EfRepositoryBase<Category, Guid, ShopDbContext>, ICategoryDal
{
    public CategoryDal(ShopDbContext context) : base(context)
    {
    }
}
