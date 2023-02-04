using FluentValidation;

namespace Application.Product.Queries;

public class GetAllProductValidator:AbstractValidator<GetAllProductsQuery>
{
    public GetAllProductValidator()
    {
        
    }
}
