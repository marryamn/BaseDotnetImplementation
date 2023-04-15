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
    [Seeder(2,typeof(Role))]
    public void SeedRoles()
    {
        DbContext.AddRange(new List<Role>()
        {
            new Role()
            {
                Name = "Admin",
 
            },new()
            {
                Name = "Head Admin",
            }
        });
        DbContext.SaveChanges();

    }
    [Seeder(3,typeof(Permission))]
    public void SeedPermission()
    {
        DbContext.AddRange(new List<Permission>()
        {
            new Permission()
            {
                Name = "مشاهده محصولات",
                Code = "list-product"
 
            },new()
            {
                Name = "حذف محصولات",
                Code = "delete-product"
            },new ()
            {
                Name = "مدیریت ادمین ها",
                Code = "manage-admin"
            }
        });
        DbContext.SaveChanges();

    }
    
    [Seeder(4,typeof(RolePermission))]
    public void SeedRolePermissions()
    {
        var roles = DbContext.Roles.ToList();
        var permissions = DbContext.Permissions.ToList();

        roles.ForEach(x =>
        {
            permissions.ForEach(y =>
            {
                DbContext.Add(new RolePermission()
                {
                    RoleId = x.Id,
                    PermissionId = y.Id

                });
            });
        });

            DbContext.SaveChanges();

    }
    
    [Seeder(5,typeof(User))]
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
    
    [Seeder(6,typeof(Admin))]
    public void SeedAdmins()
    {
        var roles = DbContext.Roles.ToList();
        DbContext.AddRange(new List<Admin>()
        {
            new Admin()
            {
                Name = "User 1",
                Email = "test@gmail.com",
                Phone = "09142564968",
                Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                RoleId = roles.First().Id,
                
            },new()
            {
                Name = "User 2",
                Email = "test2@gmail.com",
                Phone = "09142564967",
                Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                RoleId = roles.Last().Id,
               
            }
        });
        DbContext.SaveChanges();

    }
}