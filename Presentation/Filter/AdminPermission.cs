using System.Security.Claims;
using Application.Common.Response;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Filter;

public class AdminPermission:ActionFilterAttribute
{
    private readonly string _permission;
    

    public AdminPermission(string permission)
    {
        _permission = permission;
       
    }
    public AdminPermission(string permission,AppDbContext dbContext)
    {
        _permission = permission;
       
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Admin? admin=(Admin)context.HttpContext.Items["User"]!;
       
       
        if (admin.Role.RolePermissions.Select(x => x.Permission.Code).All(x => x != _permission))
        {
           
            
            context.Result =StdResponseFormat.PermissionDeniedMsg<object>("شما به این قسمت دسترسی ندارید.");
            return;
        }

        await next();
    }
    
    
  
}