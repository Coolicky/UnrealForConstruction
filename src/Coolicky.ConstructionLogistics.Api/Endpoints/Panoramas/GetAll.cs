using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Panoramas;

public class GetAll : EndpointBaseAsync.WithRequest<RequestDto>.WithActionResult<IEnumerable<Panorama>>
{
    
    private readonly IUnrealFileRepository<Panorama> _repository;

    public GetAll(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/panorama")]
    [SwaggerOperation(
        Summary = "Gets all Panoramas",
        Description = "Gets all Panoramas",
        OperationId = "Panoramas.GetAll",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<Panorama>>> HandleAsync([FromRoute] RequestDto request, CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll(request.ProjectId);
    }
}