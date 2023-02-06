using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class GetAll : EndpointBaseAsync.WithoutRequest.WithActionResult<IEnumerable<Project>>
{
    [HttpGet("api/v{version:apiVersion}/panorama/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all Projects",
        Description = "Gets all Projects",
        OperationId = "Projects.GetAll",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override Task<ActionResult<IEnumerable<Project>>> HandleAsync(CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}