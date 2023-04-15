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
   
    
    [Seeder(2,typeof(User))]
    public void SeedUsers()
    {
        DbContext.AddRange(new List<User>()
        {
            new User()
            {
                Name = "User 1",
                Email = "test@gmail.com",
                Phone = "09142564968",
                Password = BCrypt.Net.BCrypt.HashPassword("12345678")
                
            },new()
            {
                Name = "User 2",
                Email = "test2@gmail.com",
                Phone = "09142564967",
                Password = BCrypt.Net.BCrypt.HashPassword("12345678")
               
            }
        });
        DbContext.SaveChanges();

    }
    
    [Seeder(3,typeof(Admin))]
    public void SeedAdmins()
    {
        DbContext.AddRange(new List<Admin>()
        {
            new Admin()
            {
                Name = "User 1",
                Email = "test@gmail.com",
                Phone = "09142564968",
                Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                
            },new()
            {
                Name = "User 2",
                Email = "test2@gmail.com",
                Phone = "09142564967",
                Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
               
            }
        });
        DbContext.SaveChanges();

    }
}