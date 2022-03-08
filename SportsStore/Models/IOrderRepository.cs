using System.Linq;

namespace SportsStore.Models {

    /// <summary>
    /// interface iorderrepository
    /// </summary>
    public interface IOrderRepository {

        /// <summary>
        /// Unutk menyimpan order
        /// </summary>
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
