using DataAccesss.EFCore.Entities;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.EFCore.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationContext context)
           : base(context) { }


        public ICollection<Product> GetStoreProducts(int storeId)
        {
            return _context.Stores.Include(s => s.Products).FirstOrDefault(s => s.Id == storeId)?.Products;
        }

        public void AddProductToStore(int storeId, Product product)
        {
            _context.Stores.Include(s => s.Products).FirstOrDefault(s => s.Id == storeId)?.Products.Add(product);
        }

        public void RemoveProductFromStore(int storeId, Product product)
        {
            _context.Stores.Include(s => s.Products).First(s => s.Id == storeId).Products.Remove(product);
        }
    }
}
