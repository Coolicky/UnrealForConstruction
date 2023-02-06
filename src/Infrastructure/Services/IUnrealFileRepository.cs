using Microsoft.AspNetCore.Http;
using Models;

namespace Infrastructure.Services;

public interface IUnrealFileRepository<T> : IUnrealRepository<T> where T : class, IFileEntity
{
    Task<string?> GetUrl(T entity);
    Task<T?> Upload(IFormFile file, T entity);
}