using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Panoramas;

public class Download : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Download(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Panorama Picture",
        Description = "Downloads Panorama Picture",
        OperationId = "Panoramas.Download",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var panorama = await _repository.Get(request.Id);
        if (panorama is null) return NotFound();

        var url = await _repository.GetUrl(panorama);
        if (string.IsNullOrEmpty(url)) return NotFound();

        return Redirect(url);
    }
}