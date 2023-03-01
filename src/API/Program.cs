using API.Extensions;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

services.ConfigureDatabaseProvider(config);
services.ConfigureStorageProvider(config);
services.ConfigureApiVersioning();

services.AddControllers();
services.ConfigureSwagger();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UnrealContext>();
    await UnrealContext.InitializeAsync(db);
}

if (app.Environment.IsDevelopment())
    app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();