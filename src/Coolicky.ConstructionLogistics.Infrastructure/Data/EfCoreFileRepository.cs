using Coolicky.ConstructionLogistics.Data;
using Coolicky.ConstructionLogistics.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Coolicky.ConstructionLogistics.Models;

namespace Coolicky.ConstructionLogistics.Infrastructure.Data;

public class EfCoreFileRepository<TEntity> : IUnrealFileRepository<TEntity>
    where TEntity : class, IFileEntity, IProjectEntity
{
    private readonly UnrealContext _context;
    private readonly IUnrealStorageService<TEntity> _unrealStorage;

    public EfCoreFileRepository(UnrealContext context, IUnrealStorageService<TEntity> unrealStorage)
    {
        _context = context;
        _unrealStorage = unrealStorage;
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> Get(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> Add(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity?> Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Set<TEntity>().Remove(entity);
        
        if(entity.FileType is not null)
            await _unrealStorage.Delete(id, entity.FileType);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<List<TEntity>> GetAll(int id)
    {
        return await _context.Set<TEntity>()
            .Where(r => r.ProjectId == id)
            .ToListAsync();
    }

    public async Task<string?> GetUrl(TEntity entity)
    {
        return await _unrealStorage.GetUrl(entity);
    }

    public async Task<TEntity?> Upload(IFormFile file, TEntity entity)
    {
        entity.FileType = Path.GetExtension(file.FileName)
            .Replace(".", "")
            .ToLowerInvariant();
        var stream = file.OpenReadStream();
        var fileName = $"{entity.Id}.{entity.FileType}";
        await _unrealStorage.Upload(stream,fileName, entity.Id);
        entity.Image = await _unrealStorage.GetUrl(entity);
        return await Update(entity);
    }

    public async Task<TEntity?> Upload(Stream stream, string fileName, TEntity entity)
    {
        await _unrealStorage.Upload(stream, fileName, entity.Id);
        entity.Image = await _unrealStorage.GetUrl(entity);
        entity.FileType = Path.GetExtension(fileName)
            .Replace(".", "")
            .ToLowerInvariant();
        return await Update(entity);
    }
}