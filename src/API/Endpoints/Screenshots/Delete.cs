using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    [HttpDelete("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Deletes a Screenshot",
        Description = "Deletes a Screenshot",
        OperationId = "Screenshots.Delete",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}