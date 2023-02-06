using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Panoramas;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<Panorama>>
{
    [HttpGet("api/v{version:apiVersion}/panorama/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all Panoramas",
        Description = "Gets all Panoramas",
        OperationId = "Panoramas.GetAll",
        Tags = new[] { "PanoramasEndpoint" })
    ]
    public override Task<ActionResult<IEnumerable<Panorama>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}