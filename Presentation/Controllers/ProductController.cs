using System.Net;
using Application.Common;
using Application.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers;
[Route("api/product")]
[ApiController]
public class ProductController:ControllerExtension
{
    [HttpGet]
    public async Task<ActionResult<StdResponse<PaginationModel<GetAllProductsDto>>>> AddCustomerOrder(
        [FromQuery] int page=1,[FromQuery]int pageSize=10
       )
    {
       return Base(await Mediator.Send(new GetAllProductsQuery()));
       
    }

}