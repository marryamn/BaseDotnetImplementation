
namespace Domain;

public abstract class ModelExtenstion:SoftDeletes.ModelTools.ModelExtension
{
    public long Id { get; set; }
}