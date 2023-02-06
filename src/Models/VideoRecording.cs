using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class VideoRecording : IEntity, IFileEntity
{
    [Key] public int Id { get; set; }
    public Project Project { get; set; }
    [NotMapped] public string Image { get; set; }
    public string FileType { get; set; }
}