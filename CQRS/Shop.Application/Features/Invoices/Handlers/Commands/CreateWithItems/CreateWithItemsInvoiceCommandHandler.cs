using AutoMapper;
using MediatR;
using Shop.Application.Contracts.Repositories;
using Shop.Application.Extensions;
using Shop.Application.Features.Discounts.Commands.CalculateInvoice;
using Shop.Application.Features.Invoices.Commands.CreateWithItems;
using Shop.Application.Features.Invoices.Rules;
using Shop.Domain.MongoEntities;
using System.Security.Cryptography;

namespace Shop.Application.Features.Invoices.Handlers.Commands.CreateWithItems;

public class CreateWithItemsInvoiceCommandHandler : IRequestHandler<CreateWithItemsInvoiceCommand, CreateWithItemsInvoiceResponse>
{
    InvoiceBusinessRules _invoiceBusinessRules;
    IInvoiceDal _invoiceDal;
    IMapper _mapper;
    IMediator _mediator;

    public CreateWithItemsInvoiceCommandHandler(InvoiceBusinessRules invoiceBusinessRules, IInvoiceDal invoiceDal, IMapper mapper, IMediator mediator)
    {
        _invoiceBusinessRules = invoiceBusinessRules;
        _invoiceDal = invoiceDal;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<CreateWithItemsInvoiceResponse> Handle(CreateWithItemsInvoiceCommand request, CancellationToken cancellationToken)
    {
        var customer = await _invoiceBusinessRules.GetCustomerInfo(request.CustomerId);
        var products = await _invoiceBusinessRules.GetProducts(request.InvoiceItems.Select(q => q.ProductId).ToList());
        
        var inv = new Invoice
        {
            Id= Guid.NewGuid(),
            CustomerId = customer.Id,
            CustomerFullName = string.Concat(customer.FirstName, " ", customer.LastName),
            Number = string.Concat(customer.FirstName.Substring(0, 2), RandomGenerator.CreateNumber(6)),
            InvoiceItems = _invoiceBusinessRules.CreateInvoiceItems(products, request.InvoiceItems)
        };

        inv.TotalPrice = inv.InvoiceItems.Sum(x => x.Price);
        inv.DiscountedTotalPrice = inv.TotalPrice;
        var discountedInvoice =  await _mediator.Send(new CalculateInvoiceDiscountCommand { CustomerInfo = customer, Invoice = inv });
        
        await _invoiceDal.AddAsync(discountedInvoice.Invoice);

        return _mapper.Map<CreateWithItemsInvoiceResponse>(discountedInvoice.Invoice);
    }
}
