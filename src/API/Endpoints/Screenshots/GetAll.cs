using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Screenshots;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<Screenshot>>
{
    public override Task<ActionResult<IEnumerable<Screenshot>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}