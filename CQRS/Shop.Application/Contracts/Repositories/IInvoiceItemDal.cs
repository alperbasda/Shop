using Core.Persistence.Repositories;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Contracts.Repositories;

public interface IInvoiceItemDal : IAsyncRepository<InvoiceItem, Guid>
{
}
