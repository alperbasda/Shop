using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Repositories;
using Shop.Application.Features.Customers.Queries.GetWithRolesById;
using Shop.Application.Features.Customers.Rules;

namespace Shop.Application.Features.Customers.Handlers.Queries.GetWithRolesById;

public class GetWithRolesByIdCustomerQueryHandler : IRequestHandler<GetWithRolesByIdCustomerQuery, GetWithRolesByIdCustomerResponse>
{
    ICustomerDal _customerDal;
    CustomerBusinessRules _customerBusinessRules;
    IMapper _mapper;

    public GetWithRolesByIdCustomerQueryHandler(ICustomerDal customerDal, CustomerBusinessRules customerBusinessRules, IMapper mapper)
    {
        _customerDal = customerDal;
        _customerBusinessRules = customerBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetWithRolesByIdCustomerResponse> Handle(GetWithRolesByIdCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerDal.GetAsync(w => w.Id == request.Id, include: q => q.Include(w => w.CustomerRoles).ThenInclude(x=>x.Role), cancellationToken: cancellationToken);
        
        await _customerBusinessRules.ThrowExceptionIfDataNull(customer);

        return _mapper.Map<GetWithRolesByIdCustomerResponse>(customer);
    }
}
