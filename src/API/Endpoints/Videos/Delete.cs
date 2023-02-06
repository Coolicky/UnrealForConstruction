using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<VideoRecording> _repository;

    public Delete(IUnrealFileRepository<VideoRecording> repository)
    {
        _repository = repository;
    }
    [HttpDelete("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Deletes a Video",
        Description = "Deletes a Video",
        OperationId = "Videos.Delete",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(id);
        return result ? Ok() : Problem();
    }
}