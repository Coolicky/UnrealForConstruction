using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<Screenshot>>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public GetAll(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all Screenshots",
        Description = "Gets all Screenshots",
        OperationId = "Screenshots.GetAll",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<Screenshot>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll(projectId);
    }
}