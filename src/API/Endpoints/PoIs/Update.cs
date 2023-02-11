using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

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
        var result = await _repository.Update(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}