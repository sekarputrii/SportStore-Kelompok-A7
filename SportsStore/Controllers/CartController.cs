using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers {


    /// <summary>
    /// class cart controller
    /// </summary>
    public class CartController : Controller {
        private IProductRepository repository;
        private Cart cart;



        /// <summary>
        /// repo dan cartservice
        /// </summary>
        /// <param name="repo">repo</param>
        /// <param name="cartService">pelayanan keranjang</param>
        public CartController(IProductRepository repo, Cart cartService) {
            repository = repo;
            cart = cartService;
        }

        /// <summary>
        /// return url
        /// </summary>
        /// <param name="returnUrl">return url</param>
        /// <returns>Tampilan</returns>
        public ViewResult Index(string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// menambahkan produk ke keranjang
        /// </summary>
        /// <param name="productId">produk</param>
        /// <param name="returnUrl">return url</param>
        /// <returns>Index</returns>
        public RedirectToActionResult AddToCart(int productId, string returnUrl) {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null) {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// menghapus produk dari keranjang
        /// </summary>
        /// <param name="productId">produk</param>
        /// <param name="returnUrl">return url</param>
        /// <returns>Index</returns>
        public RedirectToActionResult RemoveFromCart(int productId,
                string returnUrl) {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null) {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}