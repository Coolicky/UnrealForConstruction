using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints.Projects;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}