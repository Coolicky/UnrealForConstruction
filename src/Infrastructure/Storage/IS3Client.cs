using Minio;

namespace Infrastructure.Storage;

public interface IS3Client : IMinioClient
{
    string BucketLocation { get; set; }
    int ExpiryTime { get; set; }
}