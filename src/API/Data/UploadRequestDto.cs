using Microsoft.AspNetCore.Mvc;

namespace API.Data;

public class UploadRequestDto
{
    [FromRoute(Name = "id")] public string Id { get; set; }
    [FromForm] public IFormFile File { get; set; }
}