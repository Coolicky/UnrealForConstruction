using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    [HttpGet("api/v{version:apiVersion}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Screenshot",
        Description = "Downloads Screenshot",
        OperationId = "Screenshots.Download",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}