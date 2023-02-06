using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Add : EndpointBaseAsync.WithRequest<PoI>.WithActionResult
{
    [HttpPost("api/v{version:apiVersion}/poi")]
    [SwaggerOperation(
        Summary = "Adds new PoI",
        Description = "Adds new PoI",
        OperationId = "PoIs.Add",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(PoI poi, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}