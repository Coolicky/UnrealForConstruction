using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Panoramas;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<Panorama>>
{
    public override Task<ActionResult<IEnumerable<Panorama>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}