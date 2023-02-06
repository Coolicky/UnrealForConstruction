using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Add : EndpointBaseAsync.WithRequest<PoI>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Add(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }

    [HttpPost("api/v{version:apiVersion}/poi")]
    [SwaggerOperation(
        Summary = "Adds new PoI",
        Description = "Adds new PoI",
        OperationId = "PoIs.Add",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync(PoI poi, CancellationToken cancellationToken = new())
    {
        var result =  await _repository.Add(poi);
        if (result is null) return Problem();
        return result;
    }
}