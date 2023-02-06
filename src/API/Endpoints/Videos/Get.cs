using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<VideoRecording>
{
    private readonly IUnrealFileRepository<VideoRecording> _repository;

    public Get(IUnrealFileRepository<VideoRecording> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/video/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Video",
        Description = "Gets a Video",
        OperationId = "Videos.Get",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override async Task<ActionResult<VideoRecording>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var videoRecording = await _repository.Get(id);
        if (videoRecording is null) return NotFound();
        return videoRecording;
    }
}