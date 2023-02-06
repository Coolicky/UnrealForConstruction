using API.Data;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Videos;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads Video",
        Description = "Uploads Video",
        OperationId = "Videos.Upload",
        Tags = new[] { "VideosEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(UploadRequestDto dto, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}