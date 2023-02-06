using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Panoramas;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Panorama>
{
    public override Task<ActionResult<Panorama>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}