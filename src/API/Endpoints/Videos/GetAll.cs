using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<VideoRecording>>
{
    private readonly IUnrealFileRepository<VideoRecording> _repository;

    public GetAll(IUnrealFileRepository<VideoRecording> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all Videos",
        Description = "Gets all Videos",
        OperationId = "Videos.GetAll",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<VideoRecording>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll(projectId);
    }
}