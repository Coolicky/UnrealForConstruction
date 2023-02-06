using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Download(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Panorama Picture",
        Description = "Downloads Panorama Picture",
        OperationId = "Panoramas.Download",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var panorama = await _repository.Get(id);
        if (panorama is null) return NotFound();

        var url = await _repository.GetUrl(panorama);
        if (string.IsNullOrEmpty(url)) return NotFound();

        return Redirect(url);
    }
}