using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;

namespace SportsStore.Models {

    /// <summary>
    /// clas session cart
    /// </summary>
    public class SessionCart : Cart {

        public static Cart GetCart(IServiceProvider services) {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        /// <summary>
        /// get set session
        /// </summary>
        [JsonIgnore]
        public ISession Session { get; set; }

        /// <summary>
        /// untuk melakukan tambah data (produk dan kuantitas)
        /// </summary>
        /// <param name="product">untuk produk</param>
        /// <param name="quantity">untuk kuantitas</param>
        public override void AddItem(Product product, int quantity) {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        /// <summary>
        /// remove produk
        /// </summary>
        /// <param name="product">untuk meremove produk</param>
        public override void RemoveLine(Product product) {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }

        /// <summary>
        /// untuk clear/remove
        /// </summary>
        public override void Clear() {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
