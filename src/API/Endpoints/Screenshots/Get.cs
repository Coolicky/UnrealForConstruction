using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

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