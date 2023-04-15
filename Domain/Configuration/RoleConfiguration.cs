using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration;

public class RoleConfiguration:AbstractModelMapper<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
      
    }
}