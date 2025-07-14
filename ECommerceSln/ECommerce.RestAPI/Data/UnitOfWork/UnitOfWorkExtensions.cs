using System;
using Microsoft.VisualBasic;

namespace ECommerce.RestAPI.Data.UnitOfWork;

public static class UnitOfWorkExtensions
{
    /// <summary>
    /// Executes multiple oprations whitin a single transaction
    /// </summary>
    /// <param name="unitOfWork">Unit of work instance</param>
    /// <param name="oprations">Oprations to execute</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the opration</returns>
    public static async Task ExecuteTransactionalAsync(
        this IUnitOfWork unitOfWork,
        Func<IUnitOfWork, Task> oprations,
        CancellationToken cancellationToken = default
    )
    {
        using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await oprations(unitOfWork);
            await unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    /// <summary>
    /// Executes oprations and returns a result within a transaction
    /// </summary>
    /// <typeparam name="TResult">Return type</typeparam>
    /// <param name="unitOfWork">Unit of work instance</param>
    /// <param name="oprations">Oprations to execute</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result of the oprations</returns>
    public static async Task<TResult> ExecuteTransactionalAsync<TResult>(
        this IUnitOfWork unitOfWork,
        Func<IUnitOfWork, Task<TResult>> orpations,
        CancellationToken cancellationToken = default
    )
    {
        using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var result = await orpations(unitOfWork);
            await unitOfWork.CommitTransactionAsync(cancellationToken);
            return result;
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }

    /// <summary>
    /// Attempts to save changes and returns whether the opration was successful
    /// </summary>
    /// <param name="unitOfWork">Unit of work instance</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if successful, false otherwise</returns>
    public static async Task<bool> TrySaveAsync(
        this IUnitOfWork unitOfWork,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
