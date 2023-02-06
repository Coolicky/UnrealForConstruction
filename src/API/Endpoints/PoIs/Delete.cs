using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Delete : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    [HttpDelete("api/v{version:apiVersion}/poi")]
    [SwaggerOperation(
        Summary = "Deletes a PoI",
        Description = "Deletes a PoI",
        OperationId = "PoIs.Delete",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}