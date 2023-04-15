using Application.Common;
using Application.Common.Response;
using Application.Product.Queries;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Commands;

public class DeleteProductCommandHandler: AbstractRequestHandler<DeleteProductCommand, StdResponse<string>>
{

public DeleteProductCommandHandler(AppDbContext dbcontext,IHttpContextAccessor httpContextAccessor):base(dbcontext,httpContextAccessor)
{
}


public override async Task<StdResponse<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
{
    var product = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
    if (product == null)
    {
        return NotFound<string>();
    }

    DbContext.Remove(product);
    await DbContext.SaveChangesAsync(cancellationToken);
    return Ok("Deleted successfully.");
}
}