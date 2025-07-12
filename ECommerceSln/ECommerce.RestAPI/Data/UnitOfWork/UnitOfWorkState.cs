namespace ECommerce.RestAPI.Data.UnitOfWork;

/// <summary>
/// Enumeration representing the state of the unit of work
/// </summary>
public enum UnitOfWorkState
{
    /// <summary>
    /// Unit of work is active and ready for oprations
    /// </summary>
    Active,
    /// <summary>
    /// Unit of work is within a transaction
    /// </summary>
    InTransaction,
    /// <summary>
    /// Unit of work is being committed
    /// </summary>
    Committing,
    /// <summary>
    /// Unit of work is being rolled back
    /// </summary>
    RollingBack,
    /// <summary>
    /// Unit of work has been disposed
    /// </summary>
    Disposed
}
