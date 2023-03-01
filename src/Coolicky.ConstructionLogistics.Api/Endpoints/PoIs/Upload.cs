using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.PoIs;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Upload(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }

    [HttpPost("api/v{version:apiVersion}/project/{project:int}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads PoI Picture",
        Description = "Uploads PoI Picture",
        OperationId = "PoIs.Upload",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync([FromRoute] UploadRequestDto request,
        CancellationToken cancellationToken = new())
    {
        if (request.File is null) return BadRequest("File not Provided");
        var poI = await _repository.Get(request.Id);
        if (poI is null) return NotFound();
        var result = await _repository.Upload(request.File, poI);
        if (result is null) return Problem();
        return result;
    }
}