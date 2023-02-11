using Microsoft.AspNetCore.Mvc;

namespace API.Data;

public class PayloadRequestDto<T> : RequestDto
{
    [FromBody] public T? Payload { get; set; }
}