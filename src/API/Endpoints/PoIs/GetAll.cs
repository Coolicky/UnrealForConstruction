using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class GetAll : EndpointBaseAsync.WithRequest<int>.WithActionResult<IEnumerable<PoI>>
{
    [HttpGet("api/v{version:apiVersion}/poi/all/{projectId:int}")]
    [SwaggerOperation(
        Summary = "Gets all PoIs",
        Description = "Gets all PoIs",
        OperationId = "PoIs.GetAll",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override Task<ActionResult<IEnumerable<PoI>>> HandleAsync(int projectId, CancellationToken cancellationToken = new())
    {
        throw new NotImplementedException();
    }
}