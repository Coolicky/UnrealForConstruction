using System.ComponentModel.DataAnnotations;

namespace Coolicky.ConstructionLogistics.Models;

public class Project : IEntity
{
    [Key] public int Id { get; set; }
    public string? ProjectNumber { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public string? LinkId { get; set; }
}