using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class Add : EndpointBaseAsync.WithRequest<Project>.WithActionResult<Project>
{
    private readonly IUnrealRepository<Project> _repository;

    public Add(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpPost("api/v{version:apiVersion}/project")]
    [SwaggerOperation(
        Summary = "Adds new Project",
        Description = "Adds new Project",
        OperationId = "Projects.Add",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult<Project>> HandleAsync(Project project, CancellationToken cancellationToken = new())
    {
        var result =  await _repository.Add(project);
        if (result is null) return Problem();
        return result;
    }
}