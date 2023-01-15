using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext:DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
    {
     
    }

}