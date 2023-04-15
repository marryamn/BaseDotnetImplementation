using Domain.Configuration;
using Domain.Models;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using ProductConfiguration = Domain.Configuration.ProductConfiguration;

namespace Infrastructure;

public class AppDbContext:DbContextExtension
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
    {
     
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
       
    }

}