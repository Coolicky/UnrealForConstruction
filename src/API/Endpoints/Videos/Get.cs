using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Videos;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<VideoRecording>
{
    public override Task<ActionResult<VideoRecording>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}