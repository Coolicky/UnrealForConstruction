using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.PoIs;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<PoI>>
{
    public override Task<ActionResult<IEnumerable<PoI>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}