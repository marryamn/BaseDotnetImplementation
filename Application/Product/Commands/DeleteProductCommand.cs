using Application.Common;
using Application.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Product.Commands;

public class DeleteProductCommand:IRequest<StdResponse<string>>
{
   public long Id { get; set; }
}