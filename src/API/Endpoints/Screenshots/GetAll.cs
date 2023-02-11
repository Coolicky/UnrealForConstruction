using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class GetAll : EndpointBaseAsync.WithRequest<RequestDto>.WithActionResult<IEnumerable<Screenshot>>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public GetAll(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/screenshot")]
    [SwaggerOperation(
        Summary = "Gets all Screenshots",
        Description = "Gets all Screenshots",
        OperationId = "Screenshots.GetAll",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<Screenshot>>> HandleAsync([FromRoute] RequestDto request, CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll(request.ProjectId);
    }
}