using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models {

    /// <summary>
    /// Class product
    /// </summary>
    public class Product {
        public int ProductID { get; set; }
        
        /// <summary>
        /// informasi please masukan nama produk
        /// </summary>
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        /// <summary>
        /// informasi please masukan deskripsi barang
        /// </summary>
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        /// <summary>
        /// informasi masukan positive price
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        /// <summary>
        /// informasi masukan kategori
        /// </summary>
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
    }
}
