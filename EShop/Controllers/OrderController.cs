using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProduct _product;

        public OrderController(IProduct product)
        {
            _product = product;
        }
        public IActionResult PlaceOrder(int id, int qty =1)
        {
            var product = _product.GetProductById(id);
            if (product == null) return NotFound();
            var order = new Order
            {
                Quantity = qty,
                ProductId = product.Id,
                Discount = product.Discount,
                OldPrice = product.Price,
                ProductName = product.Name, 
            };
            if (product.Discount > 0 && qty > 1)
            {
                order.ActualPrice = (qty *(product.Price)) - ((product.Price) * 10 / 100);
            }
            else
            {
                order.ActualPrice = product.Price;
            }
            return View(order);
        }
    }
}
