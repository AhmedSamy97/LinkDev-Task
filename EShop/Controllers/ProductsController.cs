using EShop.Data;
using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EShop.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;
        }
        public IActionResult Index(int page=0)
        {
            var products = _product.GetProducts();
            var count =Convert.ToDecimal(products.Count());
            decimal dividr = count / 5;
            var ceilling = Convert.ToInt16(Math.Ceiling(dividr));

            if (page == 0)
                page = 1;
            products = products.Skip((page - 1) * 5).Take(5);

            var viewModel = new ProductViewModel { Products = products.ToList() , productCount = ceilling , CurrentPage = page};
            return View(viewModel);
        }
       
    }
}
