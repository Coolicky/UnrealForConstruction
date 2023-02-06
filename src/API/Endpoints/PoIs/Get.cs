using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Get(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/poi/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a PoI",
        Description = "Gets a PoI",
        OperationId = "PoIs.Get",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var poI = await _repository.Get(id);
        if (poI is null) return NotFound();
        return poI;
    }
}