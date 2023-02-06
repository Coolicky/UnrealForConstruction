using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Panorama>
{
    
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Get(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Panorama",
        Description = "Gets a Panorama",
        OperationId = "Panoramas.Get",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<Panorama>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var panorama = await _repository.Get(id);
        if (panorama is null) return NotFound();
        return panorama;
    }
}