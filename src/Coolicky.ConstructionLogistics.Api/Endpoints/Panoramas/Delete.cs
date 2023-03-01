using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Panoramas;

public class Delete : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Delete(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }

    [HttpDelete("api/v{version:apiVersion}/project/{project:int}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Deletes a Panorama",
        Description = "Deletes a Panorama",
        OperationId = "Panoramas.Delete",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(request.Id);
        return result ? Ok() : Problem();
    }
}