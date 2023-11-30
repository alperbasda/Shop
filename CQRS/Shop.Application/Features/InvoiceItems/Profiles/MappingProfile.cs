using AutoMapper;
using Shop.Application.Features.InvoiceItems.Commands.Create;
using Shop.Domain.MongoEntities;

namespace Shop.Application.Features.InvoiceItems.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<InvoiceItem, CreateInvoiceItemResponse>();
    }
}
