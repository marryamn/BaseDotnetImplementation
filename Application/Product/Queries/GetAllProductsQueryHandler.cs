using Application.Common;
using Application.Common.Validations;
using FluentValidation;
using FluentValidation.Results;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Application.Product.Queries;

public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, ResponseModel>
{
    private readonly AppDbContext _context;
    //private IValidator<GetAllProductsQuery> _validator;
    public GetAllProductsQueryHandler(AppDbContext context)
    {
        _context = context;
       // _validator = validator;
    }
    public async Task<ResponseModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
      
        var validationResult = await new GetAllProductValidator().ValidateAsync(request, cancellationToken);
        if (validationResult.Failed())
        {
            var result = new ResponseModel()
            {
                Data = validationResult.Messages(),
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "اطلاعات وارد شده معتبر نیست."
            };
            return result;

        }
        var product = await _context.Products.Select(x =>new GetAllProductsDto()
        {
            Name = x.Name
        } ).ToListAsync(cancellationToken: cancellationToken);
        var result1 = new ResponseModel()
        {
            Data = product,
            Message = "Success",
            StatusCode = StatusCodes.Status200OK
        };
        return result1;
    }
}