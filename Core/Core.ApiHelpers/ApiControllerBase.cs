using Microsoft.AspNetCore.Mvc;
using Core.Persistence.Models.Responses;

namespace Core.ApiHelpers;

[ApiController]
public class ApiControllerBase : ControllerBase
{
    protected IActionResult CreateActionResult<T>(Response<T> response)
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }

    protected IActionResult CreateJsonResult<T>(Response<T> response)
    {
        return new JsonResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}
