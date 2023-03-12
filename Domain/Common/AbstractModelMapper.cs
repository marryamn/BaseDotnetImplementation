using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftDeletes.ModelTools;

namespace Domain;

public abstract class AbstractModelMapper<T>:IEntityTypeConfiguration<T> where T:class
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        if (typeof(T).IsAssignableTo(typeof(ISoftDelete)))
        {
            builder.HasQueryFilter(t => ((t as ISoftDelete)!).DeletedAt == null);
        }
    }
}