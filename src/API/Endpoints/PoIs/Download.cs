using Ardalis.ApiEndpoints;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.PoIs;

public class Download : EndpointBaseAsync.WithRequest<int>.WithActionResult
{
    private readonly IUnrealFileRepository<PoI> _repository;

    public Download(IUnrealFileRepository<PoI> repository)
    {
        _repository = repository;
    }
    [HttpGet("api/v{version:apiVersion}/poi/file/{id:int}")]
    [SwaggerOperation(
        Summary = "Downloads Poi Picture",
        Description = "Downloads Poi Picture",
        OperationId = "PoIs.Download",
        Tags = new[] { "PoIsEndpoint" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken = new())
    {
        var poI = await _repository.Get(id);
        if (poI is null) return NotFound();

        var url = await _repository.GetUrl(poI);
        if (string.IsNullOrEmpty(url)) return NotFound();

        return Redirect(url);
    }
}