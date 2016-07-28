namespace StoreSample.Data.Repositories
{
    using StoreSample.Data.Interfaces;
    using StoreSample.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides the basic implementation of the <see cref="IOrderRepository"/>. The implementation
    /// is specific to SQL Server, and therefore has a dependency to the underlying context.
    /// </summary>
    public class SqlOrderRepository : IOrderRepository
    {
        private StoreSampleDbContext storeSampleDbContext;

        public SqlOrderRepository(StoreSampleDbContext storeSampleDbContext)
        {
            this.storeSampleDbContext = storeSampleDbContext;
        }

        public Order AddOrder(Order newOrder)
        {
            Guard.NotNull(this.storeSampleDbContext, "The order database context connection is null. Cannot query the order database.");

            Guard.NotNull(newOrder, "The provided order was null. Cannot create a new order in the order database from a null order.");

            this.storeSampleDbContext.Orders.Add(newOrder);

            return newOrder;
        }

        public Order GetOrderById(int orderId)
        {
            Guard.NotNull(this.storeSampleDbContext, "The order database context connection is null. Cannot query the order database.");

            return this.storeSampleDbContext.Orders.SingleOrDefault(order => order.IdOrder == orderId);
        }

        public IList<Order> GetOrders()
        {
            Guard.NotNull(this.storeSampleDbContext, "The order database context connection is null. Cannot query the order database.");

            return this.storeSampleDbContext.Orders.ToList();
        }

        public int SaveChanges()
        {
            Guard.NotNull(this.storeSampleDbContext, "The order database context connection is null. Cannot query the order database.");

            return this.storeSampleDbContext.SaveChanges();
        }
    }
}
