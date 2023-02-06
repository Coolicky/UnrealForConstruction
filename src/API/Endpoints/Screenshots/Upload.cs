using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Screenshots;

public class Upload : EndpointBaseAsync.WithRequest<IFormFile>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(IFormFile file, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}