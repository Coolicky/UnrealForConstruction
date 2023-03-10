using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coolicky.ConstructionLogistics.Models;

public class Screenshot : IFileEntity, IProjectEntity
{
    [Key] public int Id { get; set; }
    
    [ForeignKey("Project")]
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    
    [NotMapped] public string? Image { get; set; }
    public string? FileType { get; set; }
}