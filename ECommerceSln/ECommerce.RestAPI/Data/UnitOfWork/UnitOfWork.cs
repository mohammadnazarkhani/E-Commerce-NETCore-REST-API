using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ECommerce.RestAPI.Data.Repository;
using ECommerce.RestAPI.Data.UnitOfWork;
using ECommerce.RestAPI.Entities;
using ECommerce.RestAPI.Entities.Interfaces;
using ECommerce.RestAPI.Entities.Audit;

namespace ECommerce.RestAPI.Data.UnitOfWork;

/// <summary>
/// Unit of work implementation with audit logging support
/// </summary>
public class UnitOfWork(DbContext context) : IUnitOfWork
{
    private readonly DbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
    private IDbContextTransaction? _transaction;
    private bool _disposed;

    // Repository properties
    private IRepository<User>? _users;
    private IRepository<Vendor>? _vendors;
    private IRepository<Product>? _products;
    private IRepository<Category>? _categories;
    private IRepository<Cart>? _carts;
    private IRepository<CartItem>? _cartItems;
    private IRepository<Order>? _orders;
    private IRepository<OrderItem>? _orderItems;
    private IRepository<Payment>? _payments;
    private IRepository<Review>? _reviews;
    private IRepository<Question>? _questions;
    private IRepository<UserAddress>? _userAddresses;
    private IRepository<Province>? _provinces;
    private IRepository<City>? _cities;
    private IRepository<ShipmentDepartment>? _shipmentDepartments;
    private IRepository<AuditLog>? _auditLogs;

    #region Entity Repositories

    public IRepository<User> Users 
    {
        get
        {
            ThrowIfDisposed();
            return _users ??= new Repository<User>(_context);
        }
    }
    public IRepository<Vendor> Vendors { get { ThrowIfDisposed(); return _vendors ??= new Repository<Vendor>(_context); } }
    public IRepository<Product> Products { get { ThrowIfDisposed(); return _products ??= new Repository<Product>(_context); } }
    public IRepository<Category> Categories { get { ThrowIfDisposed(); return _categories ??= new Repository<Category>(_context); } }
    public IRepository<Cart> Carts { get { ThrowIfDisposed(); return _carts ??= new Repository<Cart>(_context); } }
    public IRepository<CartItem> CartItems { get { ThrowIfDisposed(); return _cartItems ??= new Repository<CartItem>(_context); } }
    public IRepository<Order> Orders { get { ThrowIfDisposed(); return _orders ??= new Repository<Order>(_context); } }
    public IRepository<OrderItem> OrderItems { get { ThrowIfDisposed(); return _orderItems ??= new Repository<OrderItem>(_context); } }
    public IRepository<Payment> Payments { get { ThrowIfDisposed(); return _payments ??= new Repository<Payment>(_context); } }
    public IRepository<Review> Reviews { get { ThrowIfDisposed(); return _reviews ??= new Repository<Review>(_context); } }
    public IRepository<Question> Questions { get { ThrowIfDisposed(); return _questions ??= new Repository<Question>(_context); } }
    public IRepository<UserAddress> UserAddresses { get { ThrowIfDisposed(); return _userAddresses ??= new Repository<UserAddress>(_context); } }
    public IRepository<Province> Provinces { get { ThrowIfDisposed(); return _provinces ??= new Repository<Province>(_context); } }
    public IRepository<City> Cities { get { ThrowIfDisposed(); return _cities ??= new Repository<City>(_context); } }
    public IRepository<ShipmentDepartment> ShipmentDepartments { get { ThrowIfDisposed(); return _shipmentDepartments ??= new Repository<ShipmentDepartment>(_context); } }

    // Audit repository (not exposed in interface but used internally)
    private IRepository<AuditLog> AuditLogs => _auditLogs ??= new Repository<AuditLog>(_context);

    #endregion

    #region Generic Repository Access

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
    {
        var type = typeof(TEntity);

        if (_repositories.ContainsKey(type))
        {
            return (IRepository<TEntity>)_repositories[type];
        }

        var repository = new Repository<TEntity>(_context);
        _repositories[type] = repository;
        return repository;
    }

    #endregion

    #region Transaction Management

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        ThrowIfDisposed();
        _transaction?.Dispose();
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        State = UnitOfWorkState.InTransaction;
        return _transaction;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null)
            throw new InvalidOperationException("No active transaction to commit.");

        try
        {
            await _transaction.CommitAsync(cancellationToken);
            State = UnitOfWorkState.Committing;
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = null;
            State = UnitOfWorkState.Active;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null)
            throw new InvalidOperationException("No active transaction to rollback.");

        try
        {
            await _transaction.RollbackAsync(cancellationToken);
            State = UnitOfWorkState.RollingBack;
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = null;
            State = UnitOfWorkState.Active;
        }
    }

    public async Task<TResult> ExecuteInTransactionAsync<TResult>(
        Func<Task<TResult>> operation,
        CancellationToken cancellationToken = default)
    {
        if (operation == null)
            throw new ArgumentNullException(nameof(operation));

        using var transaction = await BeginTransactionAsync(cancellationToken);
        try
        {
            var result = await operation();
            await CommitTransactionAsync(cancellationToken);
            return result;
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    public async Task ExecuteInTransactionAsync(
        Func<Task> operation,
        CancellationToken cancellationToken = default)
    {
        if (operation == null)
            throw new ArgumentNullException(nameof(operation));

        using var transaction = await BeginTransactionAsync(cancellationToken);
        try
        {
            await operation();
            await CommitTransactionAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    #endregion

    #region Save Operations

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await OnBeforeSaveChanges(cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            await OnAfterSaveChanges(result, cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            await OnSaveChangesFailed(ex, cancellationToken);
            throw;
        }
    }

    public async Task<bool> TrySaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Bulk Operations

    public async Task ExecuteBulkOperationAsync(
        Func<IUnitOfWork, Task>[] operations,
        CancellationToken cancellationToken = default)
    {
        if (operations == null || !operations.Any())
            throw new ArgumentException("Operations cannot be null or empty.", nameof(operations));

        await ExecuteInTransactionAsync(async () =>
        {
            foreach (var operation in operations)
            {
                await operation(this);
            }
            await SaveChangesAsync(cancellationToken);
        }, cancellationToken);
    }

    public async Task<int> ExecuteRawSqlAsync(
        string sql,
        object[] parameters,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException("SQL cannot be null or whitespace.", nameof(sql));

        return await _context.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
    }

    #endregion

    #region State Management

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(UnitOfWork), "This unit of work has been disposed.");
        }
    }

    public UnitOfWorkState State { get; private set; } = UnitOfWorkState.Active;

    public bool HasPendingChanges => _context.ChangeTracker.HasChanges();

    public void DiscardChanges()
    {
        foreach (var entry in _context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    entry.Reload();
                    break;
            }
        }
    }

    public async Task ResetAsync(CancellationToken cancellationToken = default)
    {
        DiscardChanges();
        _transaction?.Dispose();
        _transaction = null;
        State = UnitOfWorkState.Active;
        await Task.CompletedTask;
    }

    #endregion

    #region Events

    public event Func<CancellationToken, Task>? BeforeSaveChanges;
    public event Func<int, CancellationToken, Task>? AfterSaveChanges;
    public event Func<Exception, CancellationToken, Task>? SaveChangesFailed;

    private async Task OnBeforeSaveChanges(CancellationToken cancellationToken)
    {
        if (BeforeSaveChanges != null)
        {
            await BeforeSaveChanges(cancellationToken);
        }
    }

    private async Task OnAfterSaveChanges(int affectedRows, CancellationToken cancellationToken)
    {
        if (AfterSaveChanges != null)
        {
            await AfterSaveChanges(affectedRows, cancellationToken);
        }
    }

    private async Task OnSaveChangesFailed(Exception exception, CancellationToken cancellationToken)
    {
        if (SaveChangesFailed != null)
        {
            await SaveChangesFailed(exception, cancellationToken);
        }
    }

    #endregion

    #region Advanced Features

    public async Task CreateSavepointAsync(string name, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Savepoint name cannot be null or whitespace.", nameof(name));

        if (_transaction == null)
            throw new InvalidOperationException("No active transaction. Begin a transaction first.");

        await _context.Database.ExecuteSqlRawAsync("SAVEPOINT {0}", new[] { name }, cancellationToken);
    }

    public async Task RollbackToSavepointAsync(string name, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Savepoint name cannot be null or whitespace.", nameof(name));

        if (_transaction == null)
            throw new InvalidOperationException("No active transaction.");

        await _context.Database.ExecuteSqlRawAsync("ROLLBACK TO SAVEPOINT {0}", new[] { name }, cancellationToken);
    }

    public async Task ReleaseSavepointAsync(string name, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Savepoint name cannot be null or whitespace.", nameof(name));

        if (_transaction == null)
            throw new InvalidOperationException("No active transaction.");

        await _context.Database.ExecuteSqlRawAsync("RELEASE SAVEPOINT {0}", new[] { name }, cancellationToken);
    }

    public void SetAutoDetectChanges(bool enabled)
    {
        _context.ChangeTracker.AutoDetectChangesEnabled = enabled;
    }

    public void DetectChanges()
    {
        _context.ChangeTracker.DetectChanges();
    }

    #endregion

    #region IDisposable Implementation

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction?.Dispose();
            _repositories.Clear();
            State = UnitOfWorkState.Disposed;
            _disposed = true;
        }
    }

    #endregion
}