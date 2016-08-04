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

        public Order AddOrder(Order newOrder)
        {
            CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.AddNewOrder(newOrder);
        }

        public Order GetOrderById(int orderId)
        {
            CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.Orders.SingleOrDefault(order => order.IdOrder == orderId);
        }

        public IList<Order> GetOrders()
        {
            CheckSqlDataSource();

            return this.sqlStoreSampleDataSource.Orders.ToList();
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
