using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Data;

public abstract class EfCoreFileRepository<TEntity, TContext> : IUnrealFileRepository<TEntity>
    where TEntity : class, IFileEntity
    where TContext : DbContext
{
    private readonly TContext _context;
    private readonly IUnrealStorageService<TEntity> _unrealStorage;

    protected EfCoreFileRepository(TContext context, IUnrealStorageService<TEntity> unrealStorage)
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
        await _unrealStorage.Delete(id, entity.FileType);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<string?> GetUrl(TEntity entity)
    {
        return await _unrealStorage.GetUrl(entity);
    }

    public async Task<TEntity?> Upload(IFormFile file, TEntity entity)
    {
        await _unrealStorage.Upload(file, entity.Id);
        entity.Image = await _unrealStorage.GetUrl(entity);
        entity.FileType = Path.GetExtension(file.FileName)
            .Replace(".", "")
            .ToLowerInvariant();
        return await Update(entity);
    }
}