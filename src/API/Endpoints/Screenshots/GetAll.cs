using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<Screenshot>>
{
    [HttpGet("api/v{version:apiVersion}/panorama/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all Screenshots",
        Description = "Gets all Screenshots",
        OperationId = "Screenshots.GetAll",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override Task<ActionResult<IEnumerable<Screenshot>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}