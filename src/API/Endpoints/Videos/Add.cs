using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Add : EndpointBaseAsync.WithRequest<VideoRecording>.WithActionResult<VideoRecording>
{
    private readonly IUnrealFileRepository<VideoRecording> _repository;

    public Add(IUnrealFileRepository<VideoRecording> repository)
    {
        _repository = repository;
    }
    [HttpPost("api/v{version:apiVersion}/video")]
    [SwaggerOperation(
        Summary = "Adds new Video",
        Description = "Adds new Video",
        OperationId = "Videos.Add",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override async Task<ActionResult<VideoRecording>> HandleAsync(VideoRecording videoRecording, CancellationToken cancellationToken = new())
    {
        var result =  await _repository.Add(videoRecording);
        if (result is null) return Problem();
        return result;
    }
}