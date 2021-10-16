using System;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IStoreRepository Stores { get; }
        int Complete();
    }
}
