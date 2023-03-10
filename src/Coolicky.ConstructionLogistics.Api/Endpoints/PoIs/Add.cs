using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coolicky.ConstructionLogistics.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.PoIs;

public class Add : EndpointBaseAsync.WithRequest<PayloadRequestDto<PoI>>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Add(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }

    [HttpPost("api/v{version:apiVersion}/project/{project:int}/poi")]
    [SwaggerOperation(
        Summary = "Adds new PoI",
        Description = "Adds new PoI",
        OperationId = "PoIs.Add",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync([FromRoute] PayloadRequestDto<PoI> request, CancellationToken cancellationToken = new())
    {
        if (request.Payload is null) return BadRequest($"PoI is not provided");
        request.Payload.ProjectId = request.ProjectId;
        var result =  await _repository.Add(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}