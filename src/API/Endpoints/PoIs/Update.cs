using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Update : EndpointBaseAsync.WithRequest<PoI>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Update(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpPatch("api/v{version:apiVersion}/poi")]
    [SwaggerOperation(
        Summary = "Updates a PoI",
        Description = "Updates a PoI",
        OperationId = "PoIs.Update",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync(PoI poi, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Update(poi);
        if (result is null) return Problem();
        return result;
    }
}