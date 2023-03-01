using API.Data;
using Azure.Storage;
using Azure.Storage.Blobs;
using Data;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Minio;

namespace API.Extensions;

public static class ApplicationExtensions
{
    public static void ConfigureDatabaseProvider(this IServiceCollection services,
        ConfigurationManager config)
    {
        services.AddDbContext<UnrealContext>(options =>
        {
            var provider = config.GetValue("DB_PROVIDER", Provider.Sqlite.Name);
            if (provider == Provider.Sqlite.Name)
                options.UseSqlite(
                    config.GetValue<string>($"DB_CONNECTION_STRING")!,
                    x => x.MigrationsAssembly(Provider.Sqlite.Assembly));
            if (provider == Provider.Postgres.Name)
                options.UseSqlite(
                    config.GetConnectionString($"DB_CONNECTION_STRING")!,
                    x => x.MigrationsAssembly(Provider.Postgres.Assembly));
            if (provider == Provider.SqlServer.Name)
                options.UseSqlite(
                    config.GetConnectionString($"DB_CONNECTION_STRING")!,
                    x => x.MigrationsAssembly(Provider.SqlServer.Assembly));
        });
        services.AddTransient(typeof(IUnrealRepository<>), typeof(EfCoreRepository<>));
        services.AddTransient(typeof(IUnrealFileRepository<>), typeof(EfCoreFileRepository<>));
    }

    public static void ConfigureStorageProvider(this IServiceCollection services,
        ConfigurationManager config)
    {
        var storageProvider = config.GetValue("STORAGE_PROVIDER", "S3");
        var settings = new StorageSettings
        {
            ExpiryTime = config.GetValue<int>("STORAGE_EXPIRY"),
            BucketLocation = config.GetValue<string>("STORAGE_DEFAULT_BUCKET") ?? "logistics"
        };
        services.AddSingleton(settings);
        if (storageProvider == "S3")
        {
            var client = new MinioClient()
                .WithEndpoint(config["S3_ENDPOINT"])
                .WithCredentials(config["S3_ACCESS_KEY"], config["S3_SECRET_KEY"])
                .WithSSL(config.GetValue<bool>("S3_SSL"))
                .Build();
            services.AddSingleton(client);
            services.AddScoped(typeof(IUnrealStorageService<>), typeof(S3FileService<>));
        }
        else if (storageProvider == "Blob")
        {
            var endpoint = config["BLOB_ENDPOINT"];
            var account = config["BLOB_NAME"];
            var key = config["BLOB_KEY"];
            var client = new BlobContainerClient(new Uri($"{endpoint}/{account}/{settings.BucketLocation}"),
                new StorageSharedKeyCredential(account, key));

            services.AddSingleton(client);
            services.AddScoped(typeof(IUnrealStorageService<>), typeof(BlobFileService<>));
        }
        else
        {
            throw new Exception("Storage provider can only be a S3 or Blob");
        }
    }

    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
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
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            options.SwaggerDoc("v1", new() { Title = "Unreal API", Version = "v1" });
        });
    }

    public static void ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Unreal API v1");
        });
    }
}