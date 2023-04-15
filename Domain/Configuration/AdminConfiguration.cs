using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration;

public class AdminConfiguration:AbstractModelMapper<Admin>
{
    public override void Configure(EntityTypeBuilder<Admin> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.Role)
            .WithMany(x => x.Admins)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}