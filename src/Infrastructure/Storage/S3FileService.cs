using Azure.Storage.Blobs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Minio;
using Models;

namespace Infrastructure.Storage;

public abstract class S3FileService<T> : IUnrealStorageService<T> where T : class, IFileEntity
{
    private readonly IS3Client _client;
    private readonly string _bucketName;

    protected S3FileService(IS3Client client)
    {
        _client = client;
        _bucketName = nameof(T);
    }

    public async Task<string?> GetUrl(T entity)
    {
        var objectName = $"{entity.Id}.{entity.FileType}";
        var args = new PresignedGetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithExpiry(_client.ExpiryTime);
        return await _client.PresignedGetObjectAsync(args);
    }

    public async Task Upload(IFormFile file, int id)
    {
        var fileType = Path.GetExtension(file.FileName)
            .Replace(".", "")
            .ToLowerInvariant();
        var objectName = $"{id}.{fileType}";
        var args = new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithFileName(file.FileName)
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