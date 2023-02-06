using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Update : EndpointBaseAsync.WithRequest<VideoRecording>.WithActionResult
{
    [HttpPatch("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Updates a Video",
        Description = "Updates a Video",
        OperationId = "Videos.Update",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(VideoRecording screenshot, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}