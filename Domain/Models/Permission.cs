using SoftDeletes.Core;

namespace Domain.Models;

public class Permission:ModelExtenstion
{
    public string Name { get; set; }
    public string Code { get; set; }
    public List<RolePermission>RolePermissions { get; set; }
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