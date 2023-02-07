using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult<PoI>
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Upload(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }

    [HttpPost("api/v{version:apiVersion}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads PoI Picture",
        Description = "Uploads PoI Picture",
        OperationId = "PoIs.Upload",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult<PoI>> HandleAsync([FromRoute] UploadRequestDto dto,
        CancellationToken cancellationToken = new())
    {
        var poI = await _repository.Get(dto.Id);
        if (poI is null) return NotFound();
        var result = await _repository.Upload(dto.File, poI);
        if (result is null) return Problem();
        return result;
    }
}