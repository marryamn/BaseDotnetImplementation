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
    public async Task<ActionResult<StdResponse<List<GetAllProductsDto>>>> AddCustomerOrder(
       )
    {
       return Base(await Mediator.Send(new GetAllProductsQuery()));
       
    }

}