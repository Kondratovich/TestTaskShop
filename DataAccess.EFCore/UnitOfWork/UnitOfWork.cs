using DataAccess.EFCore.Repositories;
using DataAccesss.EFCore.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Stores = new StoreRepository(_context);
        }
        public IProductRepository Products { get; private set; }
        public IStoreRepository Stores { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
