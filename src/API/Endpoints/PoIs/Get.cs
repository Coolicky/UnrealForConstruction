using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Get : EndpointBaseAsync.WithRequest<int>.WithActionResult<PoI>
{
    [HttpGet("api/v{version:apiVersion}/poi/{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a PoI",
        Description = "Gets a PoI",
        OperationId = "PoIs.Get",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override Task<ActionResult<PoI>> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}