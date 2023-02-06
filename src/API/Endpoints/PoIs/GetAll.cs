using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<PoI>>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public GetAll(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/poi/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all PoIs",
        Description = "Gets all PoIs",
        OperationId = "PoIs.GetAll",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<PoI>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll(projectId);
    }
}