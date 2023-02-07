using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult<VideoRecording>
{
    private readonly IUnrealFileRepository<VideoRecording> _repository;

    public Upload(IUnrealFileRepository<VideoRecording> repository)
    {
        _repository = repository;
    }

    [HttpPost("api/v{version:apiVersion}/video/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads Video",
        Description = "Uploads Video",
        OperationId = "Videos.Upload",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override async Task<ActionResult<VideoRecording>> HandleAsync([FromRoute] UploadRequestDto dto,
        CancellationToken cancellationToken = new())
    {
        var videoRecording = await _repository.Get(dto.Id);
        if (videoRecording is null) return NotFound();
        var result = await _repository.Upload(dto.File, videoRecording);
        if (result is null) return Problem();
        return result;
    }
}