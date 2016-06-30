using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreSample.Data.Repositories
{
    public class SqlOrderRepository : IOrderRepository
    {
        public SqlOrderRepository(StoreSampleDbContext storeSampleDbContext)
        {

        }

        public Order AddOrder()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
