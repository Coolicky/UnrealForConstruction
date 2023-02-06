using Microsoft.AspNetCore.Http;
using Models;

namespace Infrastructure.Services;

public interface IUnrealStorageService<in T> where T : IFileEntity
{
    Task<string?> GetUrl(T entity);
    Task Upload(IFormFile file, int id);
    Task Delete(int id, string fileType);
}