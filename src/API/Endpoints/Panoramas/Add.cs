using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Add : EndpointBaseAsync.WithRequest<Panorama>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/panorama")]
    [SwaggerOperation(
        Summary = "Adds new Panorama",
        Description = "Adds new Panorama",
        OperationId = "Panoramas.Add",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(Panorama panorama, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}