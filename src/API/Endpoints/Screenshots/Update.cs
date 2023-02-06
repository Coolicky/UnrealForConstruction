using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Update : EndpointBaseAsync.WithRequest<Screenshot>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Update(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/screenshot")]
    [SwaggerOperation(
        Summary = "Updates a Screenshot",
        Description = "Updates a Screenshot",
        OperationId = "Screenshots.Update",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync(Screenshot screenshot, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Update(screenshot);
        if (result is null) return Problem();
        return result;
    }
}