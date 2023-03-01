using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.PoIs;

public class Get : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Get(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/poi/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a PoI",
        Description = "Gets a PoI",
        OperationId = "PoIs.Get",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var poI = await _repository.Get(request.Id);
        if (poI is null) return NotFound();
        return poI;
    }
}