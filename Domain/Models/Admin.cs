using SoftDeletes.Core;

namespace Domain.Models;

public class Admin : ModelExtenstion
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Password { get; set; }
    public long? RoleId { get; set; }
    public Role Role { get; set; }


    public override Task OnSoftDeleteAsync(DbContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public override void OnSoftDelete(DbContext context)
    {
    }

    public override Task LoadRelationsAsync(DbContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.CompletedTask;
    }

    public override void LoadRelations(DbContext context)
    {
    }
}