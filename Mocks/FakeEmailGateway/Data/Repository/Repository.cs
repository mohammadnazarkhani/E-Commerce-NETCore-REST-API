using System;
using FakeEmailGateway.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace FakeEmailGateway.Data.Repository;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private ApplicationDbContext context;
    private DbSet<T> set;

    public Repository(ApplicationDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context), "ApplicationDbContext cannot be null");
        this.set = context.Set<T>();
    }

    public IQueryable<T> Query => set.AsQueryable();

    public async Task AddAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        if (entity.Id == Guid.Empty)
            entity.Id = Guid.NewGuid();

        await set.AddAsync(entity);
    }

    public Task<int> CountAsync()
    {
        return set.CountAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("ID cannot be empty", nameof(id));

        var entity = await set.FindAsync(id);
        if (entity == null)
            throw new InvalidOperationException($"Entity with ID {id} not found");

        set.Remove(entity);
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("ID cannot be empty", nameof(id));

        return set.AnyAsync(e => e.Id == id);
    }

    public Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null");

        return Task.FromResult(set.AsEnumerable().Where(predicate));
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return set.ToListAsync().ContinueWith(task => (IEnumerable<T>)task.Result);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("ID cannot be empty", nameof(id));

        var entity = await set.FindAsync(id);
        if (entity == null)
            throw new InvalidOperationException($"Entity with ID {id} not found");

        return entity;
    }

    public Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than 0");

        if (pageSize < 1)
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than 0");

        return set.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ContinueWith(task => (IEnumerable<T>)task.Result);
    }

    public Task SaveChangesAsync()
    {
        if (context == null)
            throw new InvalidOperationException("ApplicationDbContext is not initialized.");

        return context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        if (entity.Id == Guid.Empty)
            throw new ArgumentException("Entity ID cannot be empty", nameof(entity));

        set.Update(entity);
        return Task.CompletedTask;
    }
}
