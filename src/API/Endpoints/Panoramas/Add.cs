using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Panoramas;

public class Add : EndpointBaseAsync.WithRequest<Panorama>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(Panorama panorama, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}