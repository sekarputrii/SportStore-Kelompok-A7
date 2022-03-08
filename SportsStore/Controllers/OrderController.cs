using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SportsStore.Controllers {


    /// <summary>
    /// class order controller
    /// </summary>
    public class OrderController : Controller {
        private IOrderRepository repository;
        private Cart cart;

        /// <summary>
        /// untuk order controller
        /// </summary>
        /// <param name="repoService">reposervice</param>
        /// <param name="cartService">cartservie</param>
        public OrderController(IOrderRepository repoService, Cart cartService) {
            repository = repoService;
            cart = cartService;
        }

        /// <summary>
        /// untuk tampilan hasil
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ViewResult List() =>
            View(repository.Orders.Where(o => !o.Shipped));
        /// <summary>
        /// kode order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID) {
            Order order = repository.Orders
                .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null) {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }


        /// <summary>
        /// untuk checkout dari order
        /// </summary>
        /// <returns></returns>
        public ViewResult Checkout() => View(new Order());


       /// <summary>
       /// saat kita order tapi keranjang kosong, maka akan muncul informasi seperti itu
       /// </summary>
       /// <param name="order">untuk melakukan order</param>
       /// <returns></returns>
        [HttpPost]
        public IActionResult Checkout(Order order) {
            if (cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid) {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            } else {
                return View(order);
            }
        }

        /// <summary>
        /// hasil tampilan
        /// </summary>
        /// <returns></returns>
        public ViewResult Completed() {
            cart.Clear();
            return View();
        }
    }
}
