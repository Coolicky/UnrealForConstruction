using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.PoIs;

public class Add : EndpointBaseAsync.WithRequest<PoI>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(PoI poi, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}