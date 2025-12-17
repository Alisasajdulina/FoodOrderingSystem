using FoodOrderingSystem.Data;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace FoodOrderingSystem.Repositories;

/// <summary>
/// Реализация универсального репозитория
/// </summary>
public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /// <summary>Получить все записи</summary>
    public async Task<IEnumerable<T>> GetAllAsync() =>
        await _dbSet.ToListAsync();

    /// <summary>Получить запись по id</summary>
    public async Task<T?> GetByIdAsync(int id) =>
        await _dbSet.FindAsync(id);

    /// <summary>Добавить запись</summary>
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>Обновить запись</summary>
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>Удалить запись</summary>
    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
