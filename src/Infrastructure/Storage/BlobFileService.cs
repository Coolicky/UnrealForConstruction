using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Models;

namespace Infrastructure.Storage;

public abstract class BlobFileService<T> : IUnrealStorageService<T> where T : class, IFileEntity
{
    private readonly IBlobServiceClient _serviceClient;
    private readonly string _className;

    protected BlobFileService(IBlobServiceClient serviceClient)
    {
        _serviceClient = serviceClient;
        _className = nameof(T);
    }

    public async Task<string?> GetUrl(T entity)
    {
        var container = _serviceClient.GetBlobContainerClient(_serviceClient.ContainerName);
        var path = $"{_className}/{entity.Id}.{entity.FileType}";
        var blobClient = container.GetBlobClient(path);

        if (blobClient == null) return null;
        if (await blobClient.ExistsAsync() != true) return null;

        if (!blobClient.CanGenerateSasUri) return null;
        var uri = blobClient.GenerateSasUri(BlobSasPermissions.Read,
            new DateTimeOffset(DateTime.Now).AddMinutes(_serviceClient.ExpiryTime));
        return uri.ToString();
    }

    public async Task Upload(IFormFile file, int id)
    {
        var fileType = Path.GetExtension(file.FileName)
            .Replace(".", "")
            .ToLowerInvariant();
        var container = _serviceClient.GetBlobContainerClient(_serviceClient.ContainerName);
        var path = $"{_className}/{id}.{fileType}";
        var blobClient = container.GetBlobClient(path);
        if (blobClient == null) return;
        
        await blobClient.UploadAsync(file.OpenReadStream());
    }

    public async Task Delete(int id, string fileType)
    {
        var container = _serviceClient.GetBlobContainerClient(_serviceClient.ContainerName);
        var path = $"{_className}/{id}.{fileType}";
        var blobClient = container.GetBlobClient(path);
        if (blobClient == null) return;

        await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
    }
}