using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models {

    /// <summary>
    /// class cart
    /// </summary>
    public class Cart {

        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>
        /// untuk menambahkan produk item
        /// </summary>
        /// <param name="product">untuk produk</param>
        /// <param name="quantity">unutk kuantitas</param>
        public virtual void AddItem(Product product, int quantity) {
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null) {
                lineCollection.Add(new CartLine {
                    Product = product,
                    Quantity = quantity
                });
            } else {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// menghapus produk
        /// </summary>
        /// <param name="product">remove</param>
        public virtual void RemoveLine(Product product) =>
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);


        /// <summary>
        /// u
        /// </summary>
        /// <returns></returns>
        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Product.Price * e.Quantity);

        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }


    //Untuk get dan set bagi class CartLine
    public class CartLine {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
