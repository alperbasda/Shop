using Core.Persistence.Repositories;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.RelationalEntities;
using Shop.Persistence.Contexts;

namespace Shop.Persistence.Repositories;

public class ProductDal : EfRepositoryBase<Product, Guid, ShopDbContext>, IProductDal
{
    public ProductDal(ShopDbContext context) : base(context)
    {
    }
}
