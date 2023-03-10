using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Screenshots;

public class Get : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Get(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/screenshot/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Screenshot",
        Description = "Gets a Screenshot",
        OperationId = "Screenshots.Get",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var screenshot = await _repository.Get(request.Id);
        if (screenshot is null) return NotFound();
        return screenshot;
    }
}