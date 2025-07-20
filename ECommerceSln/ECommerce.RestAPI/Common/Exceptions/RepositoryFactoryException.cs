using System;

namespace ECommerce.RestAPI.Common.Exceptions;


/// <summary>
/// Exception thrown by repository factory operations
/// </summary>
public class RepositoryFactoryException : Exception
{
    public RepositoryFactoryException()
    {
    }

    public RepositoryFactoryException(string? message) : base(message)
    {
    }

    public RepositoryFactoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}