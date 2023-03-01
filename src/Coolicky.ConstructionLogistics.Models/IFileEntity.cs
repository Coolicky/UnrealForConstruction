namespace Coolicky.ConstructionLogistics.Models;

public interface IFileEntity : IEntity
{
    public string? Image { get; set; }
    public string? FileType { get; set; }
}