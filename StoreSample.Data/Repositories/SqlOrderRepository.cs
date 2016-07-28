using StoreSample.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreSample.Data.Repositories
{
    /// <summary>
    /// Provides the basic implementation of the <see cref="IOrderRepository"/>. The implementation
    /// is specific to SQL Server, and therefore has a dependency to the underlying context.
    /// </summary>
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
