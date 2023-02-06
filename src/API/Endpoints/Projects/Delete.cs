using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Projects;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealRepository<Project> _repository;

    public Delete(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpDelete("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Deletes a Project",
        Description = "Deletes a Project",
        OperationId = "Projects.Delete",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(id);
        return result ? Ok() : Problem();
    }
}