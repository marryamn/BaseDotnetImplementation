using Application.Common;
using Application.Common.Validations;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Queries;

public class GetAllProductsQueryHandler : AbstractRequestHandler<GetAllProductsQuery, StdResponse<List<GetAllProductsDto>>>
{

    public GetAllProductsQueryHandler(AppDbContext dbcontext):base(dbcontext)
    {
    }

    public override async Task<StdResponse<List<GetAllProductsDto>>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var validationResult = await new GetAllProductValidator().ValidateAsync(request, cancellationToken);
        if (validationResult.Failed())
        {
            return BadRequest<List<GetAllProductsDto>>(validationResult.Messages());
        }

        var product = await DbContext.Products.Select(x => new GetAllProductsDto()
        {
            Name = x.Name
        }).ToListAsync(cancellationToken: cancellationToken);

        return Ok(product);
    }
}