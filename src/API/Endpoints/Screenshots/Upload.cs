using API.Data;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads Screenshot",
        Description = "Uploads Screenshot",
        OperationId = "Screenshots.Upload",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(UploadRequestDto dto, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}