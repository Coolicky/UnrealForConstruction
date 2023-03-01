using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Screenshots;

public class Download : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Download(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/screenshot/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Screenshot",
        Description = "Downloads Screenshot",
        OperationId = "Screenshots.Download",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var screenshot = await _repository.Get(request.Id);
        if (screenshot is null) return NotFound();

        var url = await _repository.GetUrl(screenshot);
        if (string.IsNullOrEmpty(url)) return NotFound();

        return Redirect(url);
    }
}