using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class Update : EndpointBaseAsync.WithRequest<Project>.WithActionResult<Project>
{
    private readonly IUnrealRepository<Project> _repository;

    public Update(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/project")]
    [SwaggerOperation(
        Summary = "Updates a Project",
        Description = "Updates a Project",
        OperationId = "Projects.Update",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult<Project>> HandleAsync(Project project, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Update(project);
        if (result is null) return Problem();
        return result;
    }
}