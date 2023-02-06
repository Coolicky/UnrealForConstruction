using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Projects;

public class GetAll : EndpointBaseAsync.WithoutRequest.WithActionResult<IEnumerable<Project>>
{
    public override Task<ActionResult<IEnumerable<Project>>> HandleAsync(CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}