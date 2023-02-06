using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Project>
{
    private readonly IUnrealRepository<Project> _repository;

    public Get(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Project",
        Description = "Gets a Project",
        OperationId = "Projects.Get",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult<Project>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var project = await _repository.Get(id);
        if (project is null) return NotFound();
        return project;
    }
}