using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Delete(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }

    [HttpDelete("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Deletes a Panorama",
        Description = "Deletes a Panorama",
        OperationId = "Panoramas.Delete",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(id);
        return result ? Ok() : Problem();
    }
}