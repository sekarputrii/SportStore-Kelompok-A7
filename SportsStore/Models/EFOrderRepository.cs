using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SportsStore.Models {

    /// <summary>
    /// class eforder repository
    /// </summary>
    public class EFOrderRepository : IOrderRepository {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
                            .Include(o => o.Lines)
                            .ThenInclude(l => l.Product);

        /// <summary>
        /// menyimpan hasil order
        /// </summary>
        /// <param name="order">save order</param>
        public void SaveOrder(Order order) {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0) {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
