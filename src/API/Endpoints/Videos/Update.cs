using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Videos;

public class Update : EndpointBaseAsync.WithRequest<VideoRecording>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(VideoRecording screenshot, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}