using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Projects;

public class Get : EndpointBaseAsync.WithRequest<RequestDto>.WithActionResult<Project>
{
    private readonly IUnrealRepository<Project> _repository;

    public Get(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}")]
    [SwaggerOperation(
        Summary = "Gets a Project",
        Description = "Gets a Project",
        OperationId = "Projects.Get",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult<Project>> HandleAsync([FromRoute] RequestDto request, CancellationToken cancellationToken = new())
    {
        var project = await _repository.Get(request.ProjectId);
        if (project is null) return NotFound();
        return project;
    }
}