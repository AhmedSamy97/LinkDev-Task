using EShop.Data;
using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EShop.Controllers
{
    public class AdminController : Controller
    {

        private readonly IProduct _product;
        private readonly ICategory _category;
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IProduct product , ICategory category,IUnitOfWork unitOfWork)
        {
            _product = product;
            _category = category;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Product(int categoryId=0)
        {
            var categories = _category.GetCategories().Select(c=>
                 new SelectListItem
                 {
                     Text = c.Name,
                     Value = c.Id.ToString()
                 }
            );
            var products = _product.GetProducts(categoryId).ToList();
            var productViewModel = new ProductViewModel { Products = products, Categories = categories , CategoryId = categoryId };
            return View(productViewModel);
        }
        public IActionResult Edit(int id)
        {
            var product = _product.GetProductById(id);
            if (product == null) return RedirectToAction(nameof(Product));
            product.Categories = _category.GetCategories().Select(c=>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }
            );

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {

            var oldProduct = _product.GetProductById(product.Id);
            if (product == null) return RedirectToAction(nameof(Product));
            oldProduct.Price = product.Price;
            oldProduct.Name = product.Name;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.Discount  = product.Discount;
           _unitOfWork.SaveChanges();

            return RedirectToAction(nameof(Product));
        }
        
        public IActionResult Create()
        {
            var product = new Product();
            var categories = _category.GetCategories().Select(c=>
                new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }
            );
            product.Categories = categories;
            return View(product);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _product.Create(product);
            _unitOfWork.SaveChanges();

            return RedirectToAction(nameof(Product));
        }
    }
}
