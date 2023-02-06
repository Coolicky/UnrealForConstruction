using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class Update : EndpointBaseAsync.WithRequest<Project>.WithActionResult
{
    [HttpPatch("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Updates a Project",
        Description = "Updates a Project",
        OperationId = "Projects.Update",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(Project project, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}