using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Update : EndpointBaseAsync.WithRequest<VideoRecording>.WithActionResult<VideoRecording>
{
    private readonly IUnrealFileRepository<VideoRecording> _repository;

    public Update(IUnrealFileRepository<VideoRecording> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Updates a Video",
        Description = "Updates a Video",
        OperationId = "Videos.Update",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override async Task<ActionResult<VideoRecording>> HandleAsync(VideoRecording videoRecording, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Update(videoRecording);
        if (result is null) return Problem();
        return result;
    }
}