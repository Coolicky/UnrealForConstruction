using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<Panorama>
{
    [HttpGet("api/v{version:apiVersion}/panorama/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a Panorama",
        Description = "Gets a Panorama",
        OperationId = "Panoramas.Get",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override Task<ActionResult<Panorama>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}