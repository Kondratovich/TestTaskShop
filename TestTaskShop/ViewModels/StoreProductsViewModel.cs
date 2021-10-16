using Domain.Entities;
using System.Collections.Generic;

namespace TestTaskShop.ViewModels
{
    public class StoreProductsViewModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
