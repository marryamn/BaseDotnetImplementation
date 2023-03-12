using Domain.Models;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext:DbContextExtension
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
    {
     
    }
    public DbSet<Product> Products { get; set; }

}