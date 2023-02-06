using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class PoI : IEntity, IFileEntity
{
    [Key] public int Id { get; set; }
    public Project Project { get; set; }
    public string Name { get; set; }
    public string Information { get; set; }
    public string Footer { get; set; }
    public string Icon { get; set; }
    [NotMapped] public string? Image { get; set; }
    public string FileType { get; set; }
    public string Tag { get; set; }
    public double LookDistance { get; set; }
    public string Location { get; set; }
}