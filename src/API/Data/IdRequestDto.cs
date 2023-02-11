using Microsoft.AspNetCore.Mvc;

namespace API.Data;

public class IdRequestDto : RequestDto
{
    [FromRoute(Name = "id")] public int Id { get; set; }
}