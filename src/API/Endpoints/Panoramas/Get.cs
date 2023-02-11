using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Get : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult<Panorama>
{
    
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Get(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Panorama",
        Description = "Gets a Panorama",
        OperationId = "Panoramas.Get",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<Panorama>> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var panorama = await _repository.Get(request.Id);
        if (panorama is null) return NotFound();
        return panorama;
    }
}