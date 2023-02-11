using Microsoft.AspNetCore.Mvc;

namespace API.Data;

public class UploadRequestDto : IdRequestDto
{
    [FromForm] public IFormFile File { get; set; }
}