using Application.Common;
using MediatR;

namespace Application.Product.Queries;

public class GetAllProductsQuery:IRequest<StdResponse<PaginationModel<GetAllProductsDto>>>
{
   
}