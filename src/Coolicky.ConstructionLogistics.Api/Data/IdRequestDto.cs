using Microsoft.AspNetCore.Mvc;

namespace Coolicky.ConstructionLogistics.Api.Data;

public class IdRequestDto : RequestDto
{
    [FromRoute(Name = "id")] public int Id { get; set; }
}