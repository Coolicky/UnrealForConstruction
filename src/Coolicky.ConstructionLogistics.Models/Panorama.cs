using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coolicky.ConstructionLogistics.Models;

public class Panorama : IFileEntity, IProjectEntity
{
    [Key] public int Id { get; set; }
    public string? Name { get; set; }
    
    [ForeignKey("Project")]
    public int ProjectId { get; set; }
    public virtual Project? Project { get; set; }
    
    public string? Location { get; set; }
    [NotMapped] public string? Image { get; set; }
    public string? FileType { get; set; }
}