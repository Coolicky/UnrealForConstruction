using API.Data;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

builder.Services.AddDbContext<UnrealContext>(options =>
{
    var provider = config.GetValue("Database:Provider", Provider.Sqlite.Name);
    if (provider == Provider.Sqlite.Name)
        options.UseSqlite(
            config.GetValue<string>($"Database:ConnectionStrings:{Provider.Sqlite.Name}")!,
            x => x.MigrationsAssembly(Provider.Sqlite.Assembly));
    if (provider == Provider.Postgres.Name)
        options.UseSqlite(
            config.GetConnectionString($"Database:ConnectionStrings:{Provider.Postgres.Name}")!,
            x => x.MigrationsAssembly(Provider.Postgres.Assembly));
    if (provider == Provider.SqlServer.Name)
        options.UseSqlite(
            config.GetConnectionString($"Database:ConnectionStrings:{Provider.SqlServer.Name}")!,
            x => x.MigrationsAssembly(Provider.SqlServer.Assembly));
});

services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});
services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1", new (){Title = "Unreal API", Version = "v1"});
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UnrealContext>();
    await UnrealContext.InitializeAsync(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Unreal API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();