using System.Security.Claims;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Filter;

public class UserAuthorize : ActionFilterAttribute
{
    private readonly AppDbContext _dbContext;

    public UserAuthorize(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.HttpContext.User.IsInRole("Admin"))
        {
            var admin = await _dbContext.Admins
                .Include(x => x.Role)
                .ThenInclude(x => x.RolePermissions)
                .ThenInclude(x => x.Permission)
                .FirstOrDefaultAsync(x =>
                    x.Id == long.Parse(context.HttpContext.User.FindFirstValue("id")));
            context.HttpContext.Items["User"] = admin;
        }

        if (context.HttpContext.User.IsInRole("User"))
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x =>
                    x.Id == long.Parse(context.HttpContext.User.FindFirstValue("id")));
            context.HttpContext.Items["User"] = user;
        }

        await next();
    }
}