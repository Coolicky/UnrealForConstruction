using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Screenshots;

public class Update : EndpointBaseAsync.WithRequest<Screenshot>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(Screenshot screenshot, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}