using Application.Common;
using Application.Common.Response;
using Application.Product.Commands;
using Application.Product.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;
using Presentation.Filter;

namespace Presentation.Controllers.Admin;

[ApiExplorerSettings(GroupName = "V1 AdminSwagger")]

public class ProductController:ControllerExtension
{
    [Authorize(Policy = "Admin")]
    [AdminPermission("list-product")]
    [HttpGet("admin/products")]
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