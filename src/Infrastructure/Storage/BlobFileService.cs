using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Models;

namespace Infrastructure.Storage;

public class BlobFileService<T> : IUnrealStorageService<T> where T : class, IFileEntity
{
    private readonly BlobContainerClient _client;
    private readonly StorageSettings _settings;
    private readonly string _className;

    public BlobFileService(BlobContainerClient client, StorageSettings settings)
    {
        _client = client;
        _settings = settings;
        _className = typeof(T).Name.ToLowerInvariant();
    }

    public async Task<string?> GetUrl(T entity)
    { 
        await _client.CreateIfNotExistsAsync();
        var path = $"{_className}/{entity.Id}.{entity.FileType}";
        var blobClient = _client.GetBlobClient(path);

        if (blobClient == null) return null;
        if (await blobClient.ExistsAsync() != true) return null;

        if (!blobClient.CanGenerateSasUri) return null;
        var uri = blobClient.GenerateSasUri(BlobSasPermissions.Read,
            new DateTimeOffset(DateTime.Now).AddMinutes(_settings.ExpiryTime));
        return uri.ToString();
    }

    public async Task Upload(Stream stream, string fileName, int id)
    {
        await _client.CreateIfNotExistsAsync();
        var path = $"{_className}/{fileName}";
        var blobClient = _client.GetBlobClient(path);
        if (blobClient == null) return;
        
        await blobClient.UploadAsync(stream, overwrite: true);
    }

    public async Task Delete(int id, string fileType)
    {
        await _client.CreateIfNotExistsAsync();
        var path = $"{_className}/{id}.{fileType}";
        var blobClient = _client.GetBlobClient(path);
        if (blobClient == null) return;

        await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
    }
}