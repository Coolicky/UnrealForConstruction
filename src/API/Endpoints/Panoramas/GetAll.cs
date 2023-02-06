using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<Panorama>>
{
    
    private readonly IUnrealFileRepository<Panorama> _repository;

    public GetAll(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all Panoramas",
        Description = "Gets all Panoramas",
        OperationId = "Panoramas.GetAll",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<Panorama>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll(projectId);
    }
}