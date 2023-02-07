using API.Data;
using Data;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Minio;

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
builder.Services.AddTransient(typeof(IUnrealRepository<>), typeof(EfCoreRepository<>));
builder.Services.AddTransient(typeof(IUnrealFileRepository<>), typeof(EfCoreFileRepository<>));

var storageProvider = config.GetValue("Storage:Provider", "S3");
var settings = new StorageSettings
{
    ExpiryTime = config.GetValue<int>("Storage:ExpiryTime"),
    BucketLocation = config.GetValue<string>("Storage:BucketLocation") ?? "logistics"
};
services.AddSingleton(settings);
if (storageProvider == "S3")
{
    var client = new MinioClient()
        .WithEndpoint(config["Storage:S3:endpoint"])
        .WithCredentials(config["Storage:S3:accessKey"], config["Storage:S3:secretKey"])
        .WithSSL(config.GetValue<bool>("Storage:S3:secure"))
        .Build();
    services.AddSingleton(client);
    services.AddScoped(typeof(IUnrealStorageService<>), typeof(S3FileService<>));
}
else
{
    
}

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