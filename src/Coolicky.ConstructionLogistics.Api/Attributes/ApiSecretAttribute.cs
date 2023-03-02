using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Coolicky.ConstructionLogistics.Api.Attributes;

public class ApiSecretAttribute : Attribute, IAsyncActionFilter
{
    private const string ApiKey = "ApiSecret";
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.HttpContext.Request.Headers.TryGetValue(ApiKey, out var extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "API Secret not provided"
            };
            return;
        }

        var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = appSettings.GetValue<string>(ApiKey);
        if (apiKey is null) throw new Exception("API Key not provided in Configuration");
        if (!apiKey.Equals(extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "Invalid API Secret"
            };
            return;
        }

        await next();
    }
}