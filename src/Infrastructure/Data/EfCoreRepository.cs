using Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Data;

public class EfCoreRepository<TEntity> : IUnrealRepository<TEntity> where TEntity : class, IEntity
{
    private readonly UnrealContext _context;

    public EfCoreRepository(UnrealContext context)
    {
        _context = context;
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
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }
}