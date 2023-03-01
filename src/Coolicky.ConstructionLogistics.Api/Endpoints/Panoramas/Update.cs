using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Coolicky.ConstructionLogistics.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Panoramas;

public class Update : EndpointBaseAsync.WithRequest<PayloadRequestDto<Panorama>>.WithActionResult<Panorama>
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Update(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/project/{project:int}/panorama")]
    [SwaggerOperation(
        Summary = "Updates a Panorama",
        Description = "Updates a Panorama",
        OperationId = "Panoramas.Update",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<Panorama>> HandleAsync([FromRoute] PayloadRequestDto<Panorama> request, CancellationToken cancellationToken = new())
    {
        if (request.Payload is null) return BadRequest($"Panorama is not provided");
        request.Payload.ProjectId = request.ProjectId;
        var result = await _repository.Update(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}