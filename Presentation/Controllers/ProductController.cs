using System.Net;
using Application.Common;
using Application.Product.Commands;
using Application.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers;
[Route("api/")]
[ApiController]
public class ProductController:ControllerExtension
{
    [HttpGet("/products")]
    public async Task<ActionResult<StdResponse<PaginationModel<GetAllProductsDto>>>> GetProducts(
        [FromQuery] int page=1,[FromQuery]int pageSize=10
       )
    {
       return Base(await Mediator.Send(new GetAllProductsQuery()));
       
    }
    
    [HttpDelete("product/{Id}")]
    public async Task<ActionResult<StdResponse<string>>> DeleteProduct(
        [FromRoute] DeleteProductCommand command
    )
    {
        return Base(await Mediator.Send( command));
       
    }

}