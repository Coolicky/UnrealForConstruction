using Microsoft.AspNetCore.Mvc;

namespace Coolicky.ConstructionLogistics.Api.Data;

public class RequestDto
{
    [FromRoute(Name = "project")] public int ProjectId { get; set; }
    
}