using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void Update(Product product);
        void Add(Product product);
        void Remove(Product product);
    }
}
