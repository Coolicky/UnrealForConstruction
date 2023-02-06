using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Upload(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpPost("api/v{version:apiVersion}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads Screenshot",
        Description = "Uploads Screenshot",
        OperationId = "Screenshots.Upload",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync(UploadRequestDto dto, CancellationToken cancellationToken = new())
    {
        var screenshot = await _repository.Get(dto.Id);
        if (screenshot is null) return NotFound();
        var result = await _repository.Upload(dto.File, screenshot);
        if (result is null) return Problem();
        return result;
    }
}