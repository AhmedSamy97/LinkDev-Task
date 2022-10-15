using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace EShop.Models
{
    public class ProductViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int CategoryId { get; set; }
        public int CurrentPage { get; set; }
        public int productCount { get; set; }
    }
}
