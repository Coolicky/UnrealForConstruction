using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    [HttpDelete("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Deletes a Video",
        Description = "Deletes a Video",
        OperationId = "Videos.Delete",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}