using DataAccesss.EFCore.Entities;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context)
            : base(context) { }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
        }
        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
