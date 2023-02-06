using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Panoramas;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}