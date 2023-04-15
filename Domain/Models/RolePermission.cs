using SoftDeletes.Core;

namespace Domain.Models;

public class RolePermission:ModelExtenstion
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
    public Role Role { get; set; }
    public Permission Permission { get; set; }
    public override Task OnSoftDeleteAsync(DbContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public override void OnSoftDelete(DbContext context)
    {
    }

    public override Task LoadRelationsAsync(DbContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public override void LoadRelations(DbContext context)
    {
    }
}