using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Screenshot>
{
    [HttpGet("api/v{version:apiVersion}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Screenshot",
        Description = "Gets a Screenshot",
        OperationId = "Screenshots.Get",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override Task<ActionResult<Screenshot>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}