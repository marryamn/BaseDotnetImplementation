using Application.Common;
using Application.Common.Response;
using MediatR;

namespace Application.Product.Queries;

public class GetAllProductsQuery:IRequest<StdResponse<PaginationModel<GetAllProductsDto>>>
{
   public string Name { get; set; }
}