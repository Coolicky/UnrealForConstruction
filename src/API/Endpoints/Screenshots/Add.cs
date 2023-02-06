using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Screenshots;

public class Add : EndpointBaseAsync.WithRequest<Screenshot>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(Screenshot screenshot, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}