using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Add : EndpointBaseAsync.WithRequest<Panorama>.WithActionResult<Panorama>
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Add(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    
    [HttpPost("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Adds new Panorama",
        Description = "Adds new Panorama",
        OperationId = "Panoramas.Add",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<Panorama>> HandleAsync(Panorama panorama, CancellationToken cancellationToken = new())
    {
        var result =  await _repository.Add(panorama);
        if (result is null) return Problem();
        return result;
    }
}