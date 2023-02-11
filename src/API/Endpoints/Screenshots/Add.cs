using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class Add : EndpointBaseAsync.WithRequest<PayloadRequestDto<Screenshot>>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public Add(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }
    [HttpPost("api/v{version:apiVersion}/project/{project:int}/screenshot")]
    [SwaggerOperation(
        Summary = "Adds new Screenshot",
        Description = "Adds new Screenshot",
        OperationId = "Screenshots.Add",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync([FromRoute] PayloadRequestDto<Screenshot> request, CancellationToken cancellationToken = new())
    {
        if (request.Payload is null) return BadRequest($"Screenshot is not provided");
        request.Payload.ProjectId = request.ProjectId;
        var result =  await _repository.Add(request.Payload);
        if (result is null) return Problem();
        return result;
    }
}