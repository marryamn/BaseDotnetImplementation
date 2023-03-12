using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;
using Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using DbContext = SoftDeletes.Core.DbContext;


namespace Domain.Models;

[EntityTypeConfiguration(typeof(ProductConfiguration))]
public class Product : ModelExtenstion
{
    [StringLength(80, MinimumLength = 4)] public string? Name { get; set; }

    [StringLength(80, MinimumLength = 4)] public string? Description { get; set; }

    [StringLength(80, MinimumLength = 4)] public string? Category { get; set; }

    public bool Active { get; set; } = true;

    [Column(TypeName = "decimal(10,2)")] public decimal Price { get; set; }


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