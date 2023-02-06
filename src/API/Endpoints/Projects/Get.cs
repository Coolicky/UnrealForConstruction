using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Projects;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Project>
{
    public override Task<ActionResult<Project>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}