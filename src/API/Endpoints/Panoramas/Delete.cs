using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    [HttpDelete("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Deletes a Panorama",
        Description = "Deletes a Panorama",
        OperationId = "Panoramas.Delete",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}