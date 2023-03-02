using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.PoIs;

public class Update : EndpointBaseAsync.WithRequest<PayloadRequestDto<PoI>>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Update(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/project/{project:int}/poi")]
    [SwaggerOperation(
        Summary = "Updates a PoI",
        Description = "Updates a PoI",
        OperationId = "PoIs.Update",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync([FromRoute] PayloadRequestDto<PoI> request, CancellationToken cancellationToken = new())
    {
        if (request.Payload is null) return BadRequest($"PoI is not provided");
        request.Payload.ProjectId = request.ProjectId;
        var result = await _repository.Update(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}