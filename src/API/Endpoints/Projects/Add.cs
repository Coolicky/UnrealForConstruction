using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class Add : EndpointBaseAsync.WithRequest<Project>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/project")]
    [SwaggerOperation(
        Summary = "Adds new Project",
        Description = "Adds new Project",
        OperationId = "Projects.Add",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(Project project, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}