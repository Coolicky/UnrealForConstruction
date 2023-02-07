using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Minio;
using Models;

namespace Infrastructure.Storage;

public class S3FileService<T> : IUnrealStorageService<T> where T : class, IFileEntity
{
    private readonly MinioClient _client;
    private readonly StorageSettings _settings;
    private readonly string _bucketName;

    public S3FileService(MinioClient client, StorageSettings settings)
    {
        _client = client;
        _settings = settings;
        _bucketName = typeof(T).Name.ToLowerInvariant();
    }

    public async Task<string?> GetUrl(T entity)
    {
        var objectName = $"{entity.Id}.{entity.FileType}";
        var args = new PresignedGetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithExpiry(_settings.ExpiryTime);
        return await _client.PresignedGetObjectAsync(args);
    }

    public async Task Upload(IFormFile file, int id)
    {
        var beArgs = new BucketExistsArgs()
            .WithBucket(_bucketName);
        var found = await _client.BucketExistsAsync(beArgs).ConfigureAwait(false);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs()
                .WithBucket(_bucketName);
            await _client.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        }

        var stream = file.OpenReadStream();
        
        var fileType = Path.GetExtension(file.FileName)
            .Replace(".", "")
            .ToLowerInvariant();
        var objectName = $"{id}.{fileType}";
        var args = new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithObjectSize(stream.Length)
            .WithStreamData(stream)
            .WithContentType(file.ContentType);
        await _client.PutObjectAsync(args);
    }

    public async Task Delete(int id, string fileType)
    {
        var objectName = $"{id}.{fileType}";
        var args = new RemoveObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName);
        await _client.RemoveObjectAsync(args);
    }
}