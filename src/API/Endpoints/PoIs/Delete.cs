using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.PoIs;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}