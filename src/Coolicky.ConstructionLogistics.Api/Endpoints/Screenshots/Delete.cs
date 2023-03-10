using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Screenshots;

public class Delete : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Delete(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpDelete("api/v{version:apiVersion}/project/{project:int}/screenshot/{id:int}")]
    [SwaggerOperation(
        Summary = "Deletes a Screenshot",
        Description = "Deletes a Screenshot",
        OperationId = "Screenshots.Delete",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(request.Id);
        return result ? Ok() : Problem();
    }
}