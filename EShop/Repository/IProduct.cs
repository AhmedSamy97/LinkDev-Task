using EShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace EShop.Repository
{
    public interface IProduct
    {
        IQueryable<Product> GetProducts(int catId=0);
        Product GetProductById(int id);
        void Edit(Product product);
        void Create(Product product);
    
    }
}
