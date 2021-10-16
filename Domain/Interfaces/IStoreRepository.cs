using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        ICollection<Product> GetStoreProducts(int storeId);
        void RemoveProductFromStore(int storeId, Product product);
        void AddProductToStore(int storeId, Product product);
    }
}
