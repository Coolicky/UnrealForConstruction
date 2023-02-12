using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Minio;
using Models;

namespace Infrastructure.Storage;

public class S3FileService<T> : IUnrealStorageService<T> where T : class, IFileEntity
{
    private readonly MinioClient _client;
    private readonly StorageSettings _settings;
    private readonly string _objectName;

    public S3FileService(MinioClient client, StorageSettings settings)
    {
        _client = client;
        _settings = settings;
        _objectName = typeof(T).Name.ToLowerInvariant();
    }

    public async Task<string?> GetUrl(T entity)
    {
        var objectName = $"{_objectName}/{entity.Id}.{entity.FileType}";
        var args = new PresignedGetObjectArgs()
            .WithBucket(_settings.BucketLocation)
            .WithObject(objectName)
            .WithExpiry(_settings.ExpiryTime);
        return await _client.PresignedGetObjectAsync(args);
    }

    public async Task Upload(IFormFile file, int id)
    {
        var beArgs = new BucketExistsArgs()
            .WithBucket(_settings.BucketLocation);
        var found = await _client.BucketExistsAsync(beArgs).ConfigureAwait(false);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs()
                .WithBucket(_settings.BucketLocation);
            await _client.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        }

        var stream = file.OpenReadStream();
        
        var fileType = Path.GetExtension(file.FileName)
            .Replace(".", "")
            .ToLowerInvariant();
        var objectName = $"{_objectName}/{id}.{fileType}";
        var args = new PutObjectArgs()
            .WithBucket(_settings.BucketLocation)
            .WithObject(objectName)
            .WithObjectSize(stream.Length)
            .WithStreamData(stream)
            .WithContentType(file.ContentType);
        await _client.PutObjectAsync(args);
    }

    public async Task Delete(int id, string fileType)
    {
        var objectName = $"{_objectName}/{id}.{fileType}";
        var args = new RemoveObjectArgs()
            .WithBucket(_settings.BucketLocation)
            .WithObject(objectName);
        await _client.RemoveObjectAsync(args);
    }
}