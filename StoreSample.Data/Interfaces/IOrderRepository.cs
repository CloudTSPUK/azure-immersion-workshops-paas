using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSample.Data.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrderById(int orderId);

        IList<Order> GetOrders();
        
        Order AddOrder();
    }
}
