using Core.Persistence.Repositories;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Contracts.Repositories;

public interface IInvoiceDal : IAsyncRepository<Invoice,Guid>
{
}
