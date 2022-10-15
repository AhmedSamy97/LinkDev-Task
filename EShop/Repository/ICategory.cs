using EShop.Models;
using System.Collections.Generic;

namespace EShop.Repository
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories(int id = 0);
    }
}
