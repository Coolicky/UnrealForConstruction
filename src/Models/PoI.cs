using System.ComponentModel.DataAnnotations;

namespace Models;

public class PoI : IEntity
{
    [Key] public int Id { get; set; }
    public Project Project { get; set; }
    public string Name { get; set; }
    public string Information { get; set; }
    public string Footer { get; set; }
    public string Icon { get; set; }
    public string Image { get; set; }
    public string FileType { get; set; }
    public string Tag { get; set; }
    public double LookDistance { get; set; }
    public string Location { get; set; }
}