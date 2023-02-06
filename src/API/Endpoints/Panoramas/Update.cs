using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Update : EndpointBaseAsync.WithRequest<Panorama>.WithActionResult<Panorama>
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Update(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Updates a Panorama",
        Description = "Updates a Panorama",
        OperationId = "Panoramas.Update",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<Panorama>> HandleAsync(Panorama panorama, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Update(panorama);
        if (result is null) return Problem();
        return result;
    }
}