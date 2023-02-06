using API.Data;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads Panorama Picture",
        Description = "Uploads Panorama Picture",
        OperationId = "Panoramas.Upload",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(UploadRequestDto dto, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}