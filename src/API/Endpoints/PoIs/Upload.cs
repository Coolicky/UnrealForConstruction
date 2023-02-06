using API.Data;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Upload : EndpointBaseAsync.WithRequest<UploadRequestDto>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Uploads PoI Picture",
        Description = "Uploads PoI Picture",
        OperationId = "PoIs.Upload",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(UploadRequestDto dto, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}