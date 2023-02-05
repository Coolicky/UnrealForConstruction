using System.ComponentModel.DataAnnotations;

namespace Models;

public class Project
{
    [Key] public int Id { get; set; }
    public string ProjectNumber { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string LinkId { get; set; }
}