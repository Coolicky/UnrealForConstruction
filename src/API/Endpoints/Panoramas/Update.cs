using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Update : EndpointBaseAsync.WithRequest<Panorama>.WithActionResult
{
    [HttpPatch("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Updates a Panorama",
        Description = "Updates a Panorama",
        OperationId = "Panoramas.Update",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(Panorama panorama, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}