using Application.Common.Validations;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Queries;

public class GetAllProductValidator:Validator<GetAllProductsQuery,DbContext>
{
    public GetAllProductValidator(AppDbContext context = null) : base(context)
    {
    }
}
