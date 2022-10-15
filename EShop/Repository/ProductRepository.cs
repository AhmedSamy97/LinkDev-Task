using EShop.Data;
using EShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace EShop.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Product product)
        {
            _db.Product.Add(product);

        }

        public void Edit(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            return _db.Product.Find(id);
        }

        public IQueryable<Product> GetProducts(int catId= 0)
        {
            IQueryable<Product> products = _db.Product;
            if (catId != 0)
               products =  products.Where(c => c.CategoryId == catId);

            return products;
        }

      
    }
}
