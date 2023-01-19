using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Queries;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, List<GetAllProductsDto>>
{
    private readonly AppDbContext _context;
    public GetAllProductsQueryHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<GetAllProductsDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.Select(x =>new GetAllProductsDto()
        {
            Name = x.Name
        } ).ToListAsync(cancellationToken: cancellationToken);
        return product;
    }
}