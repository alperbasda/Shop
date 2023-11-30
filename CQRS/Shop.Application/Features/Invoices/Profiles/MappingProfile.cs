using AutoMapper;
using Shop.Application.Features.Invoices.Commands.CreateWithItems;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Features.Invoices.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Invoice, CreateWithItemsInvoiceResponse>()
            .ForMember(w => w.InvoiceItems, q => q.MapFrom(e => e.InvoiceItems));
    }
}
