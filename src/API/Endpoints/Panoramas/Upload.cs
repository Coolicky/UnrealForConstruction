using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult<Panorama>
{
    private readonly IUnrealFileRepository<Panorama> _repository;

    public Upload(IUnrealFileRepository<Panorama> repository)
    {
        _repository = repository;
    }

    [HttpPost("api/v{version:apiVersion}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads Panorama Picture",
        Description = "Uploads Panorama Picture",
        OperationId = "Panoramas.Upload",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override async Task<ActionResult<Panorama>> HandleAsync([FromRoute] UploadRequestDto dto,
        CancellationToken cancellationToken = new())
    {
        var panorama = await _repository.Get(dto.Id);
        if (panorama is null) return NotFound();
        var result = await _repository.Upload(dto.File, panorama);
        if (result is null) return Problem();
        return result;
    }
}