using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common;

public class DbContextExtension:SoftDeletes.Core.DbContext
{
    public DbContextExtension()
    {
        
    }
    
    public DbContextExtension(DbContextOptions options) : base(options)
    {
    }
    
  
    
}