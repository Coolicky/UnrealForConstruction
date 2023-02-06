using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Add : EndpointBaseAsync.WithRequest<Screenshot>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Add(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpPost("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Adds new Screenshot",
        Description = "Adds new Screenshot",
        OperationId = "Screenshots.Add",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync(Screenshot screenshot, CancellationToken cancellationToken = new())
    {
        var result =  await _repository.Add(screenshot);
        if (result is null) return Problem();
        return result;
    }
}