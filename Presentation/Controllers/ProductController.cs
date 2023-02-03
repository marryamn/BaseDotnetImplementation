using System.Net;
using Application.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[Route("api/product")]
[ApiController]
public class ProductController:Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    
    public async Task<ActionResult<List<GetAllProductsDto>>> AddCustomerOrder(
       )
    {
       var dd= await _mediator.Send(new GetAllProductsQuery());
       if (dd != null)
       {
           return Ok(dd);
       }
       else
       {
           return NotFound("");
       }
    }

}