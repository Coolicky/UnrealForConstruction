using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.PoIs;

public class GetAll : EndpointBaseAsync.WithRequest<RequestDto>.WithActionResult<IEnumerable<PoI>>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public GetAll(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/poi")]
    [SwaggerOperation(
        Summary = "Gets all PoIs",
        Description = "Gets all PoIs",
        OperationId = "PoIs.GetAll",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<IEnumerable<PoI>>> HandleAsync([FromRoute] RequestDto request, CancellationToken cancellationToken = new())
    {
        return await _repository.GetAll(request.ProjectId);
    }
}