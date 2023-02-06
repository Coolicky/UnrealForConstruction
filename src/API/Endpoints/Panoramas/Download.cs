using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    [HttpGet("api/v{version:apiVersion}/panorama/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Panorama Picture",
        Description = "Downloads Panorama Picture",
        OperationId = "Panoramas.Download",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}