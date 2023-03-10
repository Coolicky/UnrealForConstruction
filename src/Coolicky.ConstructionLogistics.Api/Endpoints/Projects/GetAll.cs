using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Projects;

public class GetAll : EndpointBaseAsync.WithoutRequest.WithActionResult<IEnumerable<Project>>
{
    private readonly IUnrealRepository<Project> _repository;

    public GetAll(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project")]
    [SwaggerOperation(
        Summary = "Gets all Projects",
        Description = "Gets all Projects",
        OperationId = "Projects.GetAll",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<Project>>> HandleAsync(CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll();
    }
}