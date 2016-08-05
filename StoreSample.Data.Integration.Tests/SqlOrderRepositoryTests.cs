namespace StoreSample.Data.Integration.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Interfaces;
    using Repositories;
    using System.Linq;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SqlOrderRepositoryTests
    {
        private int expectedSeedOrderId = 2;
        private int expectedNumberOfSeedOrders = 1;

        private IStoreSampleDataSource sqlStoreSampleDataSource;
        private IOrderRepository sqlOrderRepository;
        private static Order expectedOrder;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            expectedOrder = new Order()
            {
                CreditCardNumber = "abc",
                Email = "abc@abc.com",
                FirstName = "IntegrationTest",
                HouseNumber = "House",
                LastName = "Order",
                OrderPlacedAtUtc = new DateTime(2016, 8, 5, 13, 30, 5),
                PostCode = "abc def",
                Quantity = 1,
                TelephoneNumber = "11111111111",
                TotalPrice = Convert.ToDecimal(7.79)
            };
        }

        [TestInitialize()]
        public void Initialize()
        {
            this.sqlStoreSampleDataSource = new SqlStoreSampleDataSource();

            this.sqlOrderRepository = new SqlOrderRepository(this.sqlStoreSampleDataSource);

            Book targetBook = this.sqlStoreSampleDataSource.Books[0];

            expectedOrder.Book = targetBook;
            expectedOrder.BookId = targetBook.IdBook;
        }

        [TestCleanup()]
        public void Cleanup()
        {
            this.sqlStoreSampleDataSource = null;

            StoreSampleDbContext dbContext = new StoreSampleDbContext();

            List<Order> localOrders = dbContext.Orders.ToList();

            List<Order> ordersToDelete = dbContext.Orders.Where(o => o.FirstName == expectedOrder.FirstName).ToList();

            if (ordersToDelete.Any())
            {
                dbContext.Orders.RemoveRange(ordersToDelete);
            }

            dbContext.SaveChanges();
        }

        [TestMethod]
        public void Constuctor_ValidStoreSampleDataSource_OrderRepositoryInstanceReturned()
        {
            Assert.IsNotNull(this.sqlOrderRepository);
        }

        [TestMethod]
        public void GetAllOrders_OrderRepositoryCanRetrieveDbOrders_AllSeedOrdersReturned()
        {
            List<Order> actualSeedOrders = this.sqlOrderRepository.GetAllOrders();

            Assert.IsNotNull(actualSeedOrders);
            Assert.AreEqual(expectedNumberOfSeedOrders, actualSeedOrders.Count);
        }

        [TestMethod]
        public void GetOrderById_SeedOrderIdPresentInDb_SeedOrderReturned()
        {
            Order actualSeedOrder = this.sqlOrderRepository.GetOrderById(expectedSeedOrderId);

            Assert.IsNotNull(expectedSeedOrderId);
            Assert.AreEqual(expectedSeedOrderId, actualSeedOrder.IdOrder);
        }

        [TestMethod]
        public void AddNewOrder_AbleToAddNewOrderToLocalSqlDbContext_OrderReturned()
        {
            Order actualOrder = this.sqlOrderRepository.AddOrder(expectedOrder);

            Assert.IsNotNull(actualOrder);
            Assert.AreSame(expectedOrder, actualOrder);

            Assert.AreEqual(expectedNumberOfSeedOrders, this.sqlStoreSampleDataSource.Orders.Count);
        }

        [TestMethod]
        public void AddNewOrderThenSaveChanges_NewOrderPersistedToSqlAzure_Success()
        {
            Order actualOrder = this.sqlOrderRepository.AddOrder(expectedOrder);

            bool success = sqlStoreSampleDataSource.SaveChanges();

            Assert.IsTrue(success);
            Assert.AreEqual(expectedNumberOfSeedOrders + 1, sqlStoreSampleDataSource.Orders.Count);
        }
    }
}
