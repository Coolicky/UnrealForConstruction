using Ardalis.ApiEndpoints;
using Coolicky.ConstructionLogistics.Api.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Coolicky.ConstructionLogistics.Api.Endpoints.PoIs;

public class Download : EndpointBaseAsync.WithRequest<IdRequestDto>.WithActionResult
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Download(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/project/{project:int}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Poi Picture",
        Description = "Downloads Poi Picture",
        OperationId = "PoIs.Download",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync([FromRoute] IdRequestDto request, CancellationToken cancellationToken = new())
    {
        var poI = await _repository.Get(request.Id);
        if (poI is null) return NotFound();

        var url = await _repository.GetUrl(poI);
        if (string.IsNullOrEmpty(url)) return NotFound();

        return Redirect(url);
    }
}