using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Update : EndpointBaseAsync.WithRequest<Screenshot>.WithActionResult
{
    [HttpPatch("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Updates a Screenshot",
        Description = "Updates a Screenshot",
        OperationId = "Screenshots.Update",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(Screenshot screenshot, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}