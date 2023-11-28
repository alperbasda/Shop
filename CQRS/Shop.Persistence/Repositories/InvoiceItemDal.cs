using Core.Persistence.Models;
using MongoDbAdapter.Repository;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.MongoEntities;

namespace Shop.Persistence.Repositories;

public class InvoiceItemDal : MongoRepositoryBase<InvoiceItem, Guid>, IInvoiceItemDal
{
    public InvoiceItemDal(DatabaseOptions settings) : base(settings)
    {
    }
}
