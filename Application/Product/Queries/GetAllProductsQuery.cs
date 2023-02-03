using Application.Common;
using MediatR;

namespace Application.Product.Queries;

public class GetAllProductsQuery:IRequest<ResponseModel>
{
    public  string Name { get; set; }
}