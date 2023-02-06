using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Videos;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<VideoRecording>>
{
    public override Task<ActionResult<IEnumerable<VideoRecording>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}