namespace Models;

public interface IEntity
{
    public int Id { get; set; }
}

public interface IFileEntity
{
    public string Image { get; set; }
    public string FileType { get; set; }
}