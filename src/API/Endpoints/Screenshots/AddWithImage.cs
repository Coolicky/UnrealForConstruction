using System.Buffers.Text;
using API.Data;
using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.Screenshots;

public class AddWithImage : EndpointBaseAsync.WithRequest<PayloadRequestDto<Screenshot>>.WithActionResult<Screenshot>
{
    private readonly IUnrealFileRepository<Screenshot> _repository;

    public AddWithImage(IUnrealFileRepository<Screenshot> repository)
    {
        _repository = repository;
    }

    [HttpPost("api/v{version:apiVersion}/project/{project:int}/screenshot/file")]
    [SwaggerOperation(
        Summary = "Adds new Screenshot",
        Description = "Adds new Screenshot",
        OperationId = "Screenshots.Add",
        Tags = new[] { "ScreenshotsEndpoint" })
    ]
    public override async Task<ActionResult<Screenshot>> HandleAsync([FromRoute] PayloadRequestDto<Screenshot> request,
        CancellationToken cancellationToken = new())
    {
        if (request.Payload?.Image is null) return BadRequest($"Image is not Provided");
        request.Payload.ProjectId = request.ProjectId;
        var image = Convert.FromBase64String(request.Payload.Image);
        var stream = new MemoryStream(image);
        
        request.Payload.Image = "";
        var screenshot = await _repository.Add(request.Payload);
        if (screenshot is null) return Problem("Could not save Screenshot!");

        var result = await _repository.Upload(stream, $"{screenshot.Id}.png", screenshot);
        if (result is null) return Problem("Could not upload Screenshot");
        return result;
    }
}