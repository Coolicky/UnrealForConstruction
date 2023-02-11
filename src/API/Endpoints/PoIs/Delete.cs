using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Delete : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Delete(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    
    [HttpDelete("api/v{version:apiVersion}/project/{project:int}/poi/{id:int}")]
    [SwaggerOperation(
        Summary = "Deletes a PoI",
        Description = "Deletes a PoI",
        OperationId = "PoIs.Delete",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var result = await _repository.Delete(request.Id);
        return result ? Ok() : Problem();
    }
}