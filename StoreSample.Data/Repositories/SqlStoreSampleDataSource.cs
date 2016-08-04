namespace StoreSample.Data.Repositories
{
    using Infrastructure;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlStoreSampleDataSource : IStoreSampleDataSource
    {
        private IList<Book> books;
        private IList<Order> orders;

        StoreSampleDbContext storeSampleDbContext;

        public SqlStoreSampleDataSource()
        {
            this.storeSampleDbContext = new StoreSampleDbContext();

            this.books = storeSampleDbContext.Books.ToList();
            this.orders = storeSampleDbContext.Orders.ToList();
        }

        public IList<Book> Books
        {
            get
            {
                this.SyncBookCollectionWithDatabase();

                return this.books;
            }

            set
            {
                this.books = value;
            }
        }

        public IList<Order> Orders
        {
            get
            {
                this.SyncOrderCollectionWithDatabase();

                return this.orders;
            }

            set
            {
                this.orders = value;
            }
        }

        public Order AddNewOrder(Order order)
        {
            Guard.NotNull(order, "The provided order was null. Cannot create a new order in the order database from a null order.");

            Order newOrder = this.storeSampleDbContext.Orders.Add(order);

            this.SyncOrderCollectionWithDatabase();

            return newOrder;
        }

        public bool SaveChanges()
        {
            int result = this.storeSampleDbContext.SaveChanges();

            return result != 0;
        }

        private void SyncBookCollectionWithDatabase()
        {
            this.Books = this.storeSampleDbContext.Books.ToList();
        }

        private void SyncOrderCollectionWithDatabase()
        {
            this.Orders = this.storeSampleDbContext.Orders.ToList();
        }
    }
}
