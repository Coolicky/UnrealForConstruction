using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Panorama
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public virtual Project Project { get; set; }
    public string Location { get; set; }
    [NotMapped] public string Image { get; set; }
    public string FileType { get; set; }
}