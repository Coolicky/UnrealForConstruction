using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Screenshots;

public class Update : EndpointBaseAsync.WithRequest<PayloadRequestDto<Screenshot>>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Update(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/project/{project:int}/screenshot")]
    [SwaggerOperation(
        Summary = "Updates a Screenshot",
        Description = "Updates a Screenshot",
        OperationId = "Screenshots.Update",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync([FromRoute] PayloadRequestDto<Screenshot> request, CancellationToken cancellationToken = new())
    {
        if (request.Payload is null) return BadRequest($"Screenshot is not provided");
        request.Payload.ProjectId = request.ProjectId;
        var result = await _repository.Update(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}