using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Update : EndpointBaseAsync.WithRequest<PoI>.WithActionResult
{
    [HttpPatch("api/v{version:apiVersion}/poi")]
    [SwaggerOperation(
        Summary = "Updates a PoI",
        Description = "Updates a PoI",
        OperationId = "PoIs.Update",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(PoI poi, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}