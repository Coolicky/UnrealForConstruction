using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<VideoRecording>
{
    [HttpGet("api/v{version:apiVersion}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Video",
        Description = "Gets a Video",
        OperationId = "Videos.Get",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override Task<ActionResult<VideoRecording>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}