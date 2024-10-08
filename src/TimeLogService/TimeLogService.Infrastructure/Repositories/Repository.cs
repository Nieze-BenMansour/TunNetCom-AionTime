﻿namespace TimeLogService.Infrastructure.Repositories;

public class Repository<T>(TunNetComAionTimeTimeLogServiceDataBaseContext context)
    : IRepository<T>
    where T : BaseEntity
{
    private readonly TunNetComAionTimeTimeLogServiceDataBaseContext _context = context;

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.AddRangeAsync(entities);
        _ = await _context.SaveChangesAsync();
    }

    public async Task AddAsync(T entity)
    {
        _ = await _context.AddAsync(entity);
        _ = await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        T? entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id)
            ?? throw new KeyNotFoundException(id.ToString());

        _ = _context.Remove(entity);
        _ = await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _ = _context.Entry(entity).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _ = _context.Entry(entities).State = EntityState.Modified;
        _ = await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _context.RemoveRange(entities);
        _ = await _context.SaveChangesAsync();
    }
}