using API.Extensions;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;


services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://auth.pmgroupdigital.com/application/o/construction-logistics/";
        options.Audience = "ef016c17dbcd830377fe57e99f035f0c1604b3d7";
    });

services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();

app.Run();