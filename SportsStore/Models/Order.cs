using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models {

    /// <summary>
    /// Class Order
    /// </summary>
    public class Order {

        /// <summary>
        /// 
        /// </summary>
        [BindNever]
        public int OrderID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BindNever]
        public bool Shipped { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        /// <summary>
        /// Informasi diharapkan untuk memasukan first address line
        /// </summary>
        [Required(ErrorMessage = "Please enter the first address line")]
           
        public string Line1 { get; set; }
        /// <summary>
        /// line 2
        /// </summary>
        public string Line2 { get; set; }
        /// <summary>
        /// line 3
        /// </summary>
        public string Line3 { get; set; }

        /// <summary>
        /// Informasi please enter nama kota
        /// </summary>

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        /// <summary>
        /// informasi please enter a nama state
        /// </summary>

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        public string Zip { get; set; }

        /// <summary>
        /// informasi enter nama negara
        /// </summary>
        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
