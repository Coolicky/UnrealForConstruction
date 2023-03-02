using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Panoramas;

public class Add : EndpointBaseAsync.WithRequest<PayloadRequestDto<Panorama>>.WithActionResult<Panorama>
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Add(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    
    [HttpPost("api/v{version:apiVersion}/project/{project:int}/panorama")]
    [SwaggerOperation(
        Summary = "Adds new Panorama",
        Description = "Adds new Panorama",
        OperationId = "Panoramas.Add",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<Panorama>> HandleAsync([FromRoute] PayloadRequestDto<Panorama> request, CancellationToken cancellationToken = new())
    {
        if (request.Payload is null) return BadRequest($"Panorama is not provided");
        request.Payload.ProjectId = request.ProjectId;
        var result =  await _repository.Add(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}