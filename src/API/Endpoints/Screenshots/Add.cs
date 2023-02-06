using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Add : EndpointBaseAsync.WithRequest<Screenshot>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Adds new Screenshot",
        Description = "Adds new Screenshot",
        OperationId = "Screenshots.Add",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(Screenshot screenshot, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}