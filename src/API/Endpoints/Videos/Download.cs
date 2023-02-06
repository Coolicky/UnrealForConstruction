using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<VideoRecording> _repository;

    public Download(IUnrealFileRepository<VideoRecording> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Video",
        Description = "Downloads Video",
        OperationId = "Videos.Download",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var videoRecording = await _repository.Get(id);
        if (videoRecording is null) return NotFound();

        var url = await _repository.GetUrl(videoRecording);
        if (string.IsNullOrEmpty(url)) return NotFound();

        return Redirect(url);
    }
}