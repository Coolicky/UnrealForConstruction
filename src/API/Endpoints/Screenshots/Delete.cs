using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Delete(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpDelete("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Deletes a Screenshot",
        Description = "Deletes a Screenshot",
        OperationId = "Screenshots.Delete",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(id);
        return result ? Ok() : Problem();
    }
}