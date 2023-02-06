using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Get(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Screenshot",
        Description = "Gets a Screenshot",
        OperationId = "Screenshots.Get",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var screenshot = await _repository.Get(id);
        if (screenshot is null) return NotFound();
        return screenshot;
    }
}