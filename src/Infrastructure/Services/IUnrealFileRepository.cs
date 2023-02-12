using Microsoft.AspNetCore.Http;
using Models;

namespace Infrastructure.Services;

public interface IUnrealFileRepository<T> : IUnrealRepository<T> where T : class, IFileEntity
{
    Task<List<T>> GetAll(int id);
    Task<string?> GetUrl(T entity);
    Task<T?> Upload(IFormFile file, T entity);
    Task<T?> Upload(Stream stream, string fileName, T entity);
}