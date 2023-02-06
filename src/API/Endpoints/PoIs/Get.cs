using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.PoIs;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<PoI>
{
    public override Task<ActionResult<PoI>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}