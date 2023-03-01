using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Projects;

public class Delete : EndpointBaseAsync.WithRequest<RequestDto>.WithActionResult
{
    private readonly IUnrealRepository<Project> _repository;

    public Delete(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpDelete("api/v{version:apiVersion}/project/{project:int}")]
    [SwaggerOperation(
        Summary = "Deletes a Project",
        Description = "Deletes a Project",
        OperationId = "Projects.Delete",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] RequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(request.ProjectId);
        return result ? Ok() : Problem();
    }
}