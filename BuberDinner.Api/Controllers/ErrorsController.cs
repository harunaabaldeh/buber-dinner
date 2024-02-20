using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, Message) = exception switch
        {
            IServiceExtension serviceExtension => ((int)serviceExtension.StatusCode, serviceExtension.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An error occurred")
        };

        return Problem(statusCode: statusCode, title: Message);
    }
}