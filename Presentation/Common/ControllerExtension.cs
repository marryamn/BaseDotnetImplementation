using System.Net.Mime;
using Application.Common;
using Application.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Presentation.Common;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1")]
public class ControllerExtension:Controller
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    
    protected ActionResult<StdResponse<T>> Base<T>(StdResponse<T> response)
    {
        return StdResponseFormat.Base(response);
    }
}