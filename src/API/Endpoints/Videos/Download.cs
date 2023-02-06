using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    [HttpGet("api/v{version:apiVersion}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Video",
        Description = "Downloads Video",
        OperationId = "Videos.Download",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}