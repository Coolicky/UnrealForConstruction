using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.Projects;

public class Update : EndpointBaseAsync.WithRequest<PayloadRequestDto<Project>>.WithActionResult<Project>
{
    private readonly IUnrealRepository<Project> _repository;

    public Update(IUnrealRepository<Project> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/project/{project:int}")]
    [SwaggerOperation(
        Summary = "Updates a Project",
        Description = "Updates a Project",
        OperationId = "Projects.Update",
        Tags = new[] { "ProjectEndpoint" })
    ]
    public override async Task<ActionResult<Project>> HandleAsync([FromRoute] PayloadRequestDto<Project> request, CancellationToken cancellationToken = new())
    {
        if (request.Payload is null) return BadRequest("Project is not Provided");
        var result = await _repository.Update(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}