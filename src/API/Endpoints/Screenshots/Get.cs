using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Screenshots;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Screenshot>
{
    public override Task<ActionResult<Screenshot>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}