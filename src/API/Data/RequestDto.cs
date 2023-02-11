using Microsoft.AspNetCore.Mvc;

namespace API.Data;

public class RequestDto
{
    [FromRoute(Name = "project")] public int ProjectId { get; set; }
    
}