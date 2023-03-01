using Microsoft.AspNetCore.Mvc;

namespace Coolicky.ConstructionLogistics.Api.Data;

public class UploadRequestDto : IdRequestDto
{
    [FromForm] public IFormFile? File { get; set; }
}