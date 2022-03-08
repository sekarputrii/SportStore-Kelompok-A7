using System.Linq;

namespace SportsStore.Models {

    /// <summary>
    /// interface iproductrepository
    /// </summary>
    public interface IProductRepository {


        IQueryable<Product> Products { get; }

        /// <summary>
        /// kode di bawah ini berfungsi untuk menyimpan produk
        /// </summary>
        /// <param name="product">utuk menyimpan produk</param>
        void SaveProduct(Product product);


        /// <summary>
        /// kode di bawah ini berguna untuk menghapus produk
        /// </summary>
        /// <param name="productID">menghapus produk</param>
        /// <returns></returns>
        Product DeleteProduct(int productID);
    }
}
