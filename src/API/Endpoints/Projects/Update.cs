using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Endpoints.Projects;

public class Update : EndpointBaseAsync.WithRequest<Project>.WithActionResult
{
    public override Task<ActionResult> HandleAsync(Project project, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}