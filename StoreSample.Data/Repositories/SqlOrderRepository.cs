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
        private IStoreSampleDataSource sqlStoreSampleDataSource;

        public SqlOrderRepository(IStoreSampleDataSource sqlStoreSampleDataSource)
        {
            Guard.NotNull(sqlStoreSampleDataSource, "The passed sql data source was null. Cannot instantiate a sql book repository.");

            this.sqlStoreSampleDataSource = sqlStoreSampleDataSource;
        }

        public List<Order> GetAllOrders()
        {
            CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.Orders;
        }

        public Order GetOrderById(int orderId)
        {
            CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.Orders.SingleOrDefault(order => order.IdOrder == orderId);
        }

        public Order AddOrder(Order newOrder)
        {
            Guard.NotNull(newOrder, "The provided order was null. Cannot add a null order to order datasource.");

            CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.AddNewOrder(newOrder);
        }

        public bool SaveChanges()
        {
            CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.SaveChanges();
        }

        private void CheckSqlDataSource()
        {
            Guard.NotNull(sqlStoreSampleDataSource, "The book SQL order datasource is null. Cannot query the order datasource.");
        }
    }
}
