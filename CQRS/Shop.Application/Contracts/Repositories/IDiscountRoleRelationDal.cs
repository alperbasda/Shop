using Core.Persistence.Repositories;
using Shop.Domain.RelationalEntities;

namespace Shop.Application.Contracts.Repositories;

public interface IDiscountRoleRelationDal : IAsyncRepository<DiscountRoleRelation,Guid>
{
}
