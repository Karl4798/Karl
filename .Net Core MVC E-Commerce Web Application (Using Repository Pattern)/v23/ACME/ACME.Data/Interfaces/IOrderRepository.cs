using ACME.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ACME.Data.Interfaces
{

    // Interface used for CRUD operations for the order repository
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        List<OrderDetail> AllOrders();
        IQueryable<Order> CustomerOrders(string email);
        IQueryable<Order> CustomerOrders(string email, string orderSearch);
        Order CustomerOrder(int? id);

    }
}
