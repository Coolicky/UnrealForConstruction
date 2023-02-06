using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Download(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/screenshot/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Screenshot",
        Description = "Downloads Screenshot",
        OperationId = "Screenshots.Download",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var screenshot = await _repository.Get(id);
        if (screenshot is null) return NotFound();

        var url = await _repository.GetUrl(screenshot);
        if (string.IsNullOrEmpty(url)) return NotFound();

        return Redirect(url);
    }
}