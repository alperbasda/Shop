using Core.Persistence.Models;
using MongoDbAdapter.Repository;
using Shop.Application.Contracts.Repositories;
using Shop.Domain.MongoEntities;

namespace Shop.Persistence.Repositories;

public class InvoiceDal : MongoRepositoryBase<Invoice, Guid>, IInvoiceDal
{
    public InvoiceDal(DatabaseOptions settings) : base(settings)
    {
    }
}
