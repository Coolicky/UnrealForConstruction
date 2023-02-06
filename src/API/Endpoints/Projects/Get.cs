using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Project>
{
    [HttpGet("api/v{version:apiVersion}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Project",
        Description = "Gets a Project",
        OperationId = "Projects.Get",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override Task<ActionResult<Project>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}