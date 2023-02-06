using Azure.Storage.Blobs;

namespace Infrastructure.Storage;

public abstract class IBlobServiceClient : BlobServiceClient
{
    public string ContainerName { get; set; }
    public int ExpiryTime { get; set; }
}