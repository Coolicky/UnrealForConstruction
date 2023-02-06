using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<VideoRecording>>
{
    [HttpGet("api/v{version:apiVersion}/panorama/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all Videos",
        Description = "Gets all Videos",
        OperationId = "Videos.GetAll",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override Task<ActionResult<IEnumerable<VideoRecording>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}