using Application.Common;
using Application.Common.Validations;
using Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Application.Product.Queries;

public class GetAllProductsQueryHandler : AbstractRequestHandler<GetAllProductsQuery, StdResponse<PaginationModel<GetAllProductsDto>>>
{

    public GetAllProductsQueryHandler(AppDbContext dbcontext,IHttpContextAccessor httpContextAccessor):base(dbcontext,httpContextAccessor)
    {
    }

    public override async Task<StdResponse<PaginationModel<GetAllProductsDto>>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var validationResult = await new GetAllProductValidator().ValidateAsync(request, cancellationToken);
        if (validationResult.Failed())
        {
            return BadRequest<PaginationModel<GetAllProductsDto>>(validationResult.Messages());
        }

        var product =  DbContext.Products.Select(x => new GetAllProductsDto()
        {
            Name = x.Name
        }).GetPaged(HttpContext.Request);
        

        return Ok(product);
    }
}