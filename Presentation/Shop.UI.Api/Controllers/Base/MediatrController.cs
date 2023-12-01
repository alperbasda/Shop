using Core.ApiHelpers;
using MediatR;

namespace Shop.UI.Api.Controllers.Base;

public class MediatrController : ApiControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator
    {
        get
        {
            if (_mediator == null)
            {
                _mediator = HttpContext.RequestServices.GetService<IMediator>();
            }
            return _mediator!;
        }
    }
}
