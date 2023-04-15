using SoftDeletes.Core;

namespace Domain.Models;

public class Role:ModelExtenstion
{
    public string Name { get; set; }
    public List<RolePermission>RolePermissions { get; set; }
    public List<Admin>Admins { get; set; }
    public override Task OnSoftDeleteAsync(DbContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public override void OnSoftDelete(DbContext context)
    {
        
    }

    public override async Task LoadRelationsAsync(DbContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        await context.Entry(this)
            .Collection(x => x.RolePermissions)
            .LoadAsync(cancellationToken);
        await context.Entry(this)
            .Collection(x => x.Admins)
            .LoadAsync(cancellationToken);
    }

    public override void LoadRelations(DbContext context)
    {
        context.Entry(this)
            .Collection(x => x.RolePermissions)
            .Load();
        context.Entry(this)
            .Collection(x => x.Admins)
            .Load();
    }
}