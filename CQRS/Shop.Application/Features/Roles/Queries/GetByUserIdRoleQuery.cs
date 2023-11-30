using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Roles.Queries;

public class GetByUserIdRoleQuery : IRequest<GetByUserIdRoleResponse>
{
    public Guid UserId { get; set; }

}
