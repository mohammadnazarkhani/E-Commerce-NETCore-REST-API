using System;
using FakeEmailGateway.Data;
using FakeEmailGateway.Data.UnitOfWork;

namespace FakeEmailGateway.Services.Base;

public class ServiceBase(IUnitOfWork unitOfWork) : IService
{
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "UnitOfWork cannot be null");

    public virtual void Dispose()
    {
        UnitOfWork.Dispose();
    }
}
