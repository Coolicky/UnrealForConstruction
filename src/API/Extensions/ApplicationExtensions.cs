using API.Data;
using Data;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Storage;
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
        services.AddTransient(typeof(IUnrealRepository<>), typeof(EfCoreRepository<>));
        services.AddTransient(typeof(IUnrealFileRepository<>), typeof(EfCoreFileRepository<>));
    }

    public static void ConfigureStorageProvider(this IServiceCollection services,
        ConfigurationManager config)
    {
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
    }
}