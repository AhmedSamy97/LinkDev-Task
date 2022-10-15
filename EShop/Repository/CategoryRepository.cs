using EShop.Data;
using EShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace EShop.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db )
        {
            _db = db;
        }
        public IEnumerable<Category> GetCategories(int id=0)
        {
            var categories = _db.Category;
            if (id != 0)
                categories.Where(a => a.Id == id);

            return categories.ToList();
        }
    }
}
