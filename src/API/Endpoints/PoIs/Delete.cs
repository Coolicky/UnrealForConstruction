using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Delete(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    
    [HttpDelete("api/v{version:apiVersion}/poi")]
    [SwaggerOperation(
        Summary = "Deletes a PoI",
        Description = "Deletes a PoI",
        OperationId = "PoIs.Delete",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(id);
        return result ? Ok() : Problem();
    }
}