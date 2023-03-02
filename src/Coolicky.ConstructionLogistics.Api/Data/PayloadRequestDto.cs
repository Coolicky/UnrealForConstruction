using Microsoft.AspNetCore.Mvc;

namespace Coolicky.ConstructionLogistics.Api.Data;

public class PayloadRequestDto<T> : RequestDto
{
    [FromBody] public T? Payload { get; set; }
}