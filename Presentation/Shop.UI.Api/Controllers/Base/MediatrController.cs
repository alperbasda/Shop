using Core.ApiHelpers;
using MediatR;

namespace Shop.UI.Api.Controllers.Base;

public class MediatrController : ApiControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
