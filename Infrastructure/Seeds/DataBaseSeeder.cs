using Domain.Models;
using Ef.Seeder.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;

public class DataBaseSeeder
{
    public DataBaseSeeder(AppDbContext context)
    {
        DbContext = context;
    }
    public AppDbContext DbContext { get; set; }
    [Seeder(1,typeof(Product))]
    public void SeedProducts()
    {
       DbContext.AddRange(new List<Product>()
       {
           new Product()
           {
               Name = "product 1",
               Description = "A description for product 1",
               Category = "Category 1",
               Active = true,
               Price = 12000
           },new()
           {
               Name = "product 2",
               Description = "A description for product 1",
               Category = "Category 2",
               Active = true,
               Price = 12000
           }
       });
       DbContext.SaveChanges();

    }
}