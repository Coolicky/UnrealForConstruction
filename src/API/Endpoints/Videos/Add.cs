using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Add : EndpointBaseAsync.WithRequest<VideoRecording>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/video")]
    [SwaggerOperation(
        Summary = "Adds new Video",
        Description = "Adds new Video",
        OperationId = "Videos.Add",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(VideoRecording screenshot, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}