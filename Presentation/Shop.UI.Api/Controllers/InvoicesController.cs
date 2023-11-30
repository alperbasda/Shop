using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Invoices.Commands.CreateWithItems;
using Shop.UI.Api.Controllers.Base;

namespace Shop.UI.Api.Controllers;

[Route("fatura")]
public class InvoicesController : MediatrController
{
    //Stateless auth çalışabilir durumda.
    //[AuthorizeHandler]
    [AllowAnonymous]
    [HttpPost("faturaoluştur")]
    public async Task<IActionResult> Create(CreateWithItemsInvoiceCommand request)
    {
        return Ok(await base.Mediator.Send(request));
    }

}
