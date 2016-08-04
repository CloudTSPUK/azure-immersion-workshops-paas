namespace StoreSample.Data.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;
    using Moq;
    using System.Collections.Generic;
    using Repositories;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SqlOrderRepositoryTests
    {
        private static Mock<IStoreSampleDataSource> mockSqlStoreSampleDataSource;
        private static List<Order> expectedOrders = new List<Order>();
        private static Order expectedOrder;

        private IStoreSampleDataSource mockDataStore;
        private IOrderRepository orderRepository;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            mockSqlStoreSampleDataSource = new Mock<IStoreSampleDataSource>();

            int maxNumberOfTestOrders = 3;

            for (int i = 0; i < maxNumberOfTestOrders; i++)
            {
                expectedOrders.Add(new Order()
                {
                    IdOrder = i,
                    BookId = i,
                    Book = null,
                    CreditCardNumber = "abc",
                    Email = "abc@abc.com",
                    FirstName = "abc",
                    HouseNumber = string.Format("House {0}", i),
                    LastName = "def",
                    OrderPlacedAtUtc = new DateTime(1900, 1, 1, 1, 1, 1),
                    PostCode = "abc def",
                    Quantity = i,
                    TelephoneNumber = "11111111111",
                    TotalPrice = i
                });
            }

            expectedOrder = new Order()
            {
                IdOrder = 4,
                BookId = 4,
                Book = null,
                CreditCardNumber = "abc",
                Email = "abc@abc.com",
                FirstName = "abc",
                HouseNumber = string.Format("House {0}", 4),
                LastName = "def",
                OrderPlacedAtUtc = new DateTime(1900, 5, 5, 5, 5, 5),
                PostCode = "abc def",
                Quantity = 4,
                TelephoneNumber = "11111111111",
                TotalPrice = 4
            };

            mockSqlStoreSampleDataSource.Setup(sssds => sssds.Orders).Returns(expectedOrders);
            mockSqlStoreSampleDataSource.Setup(sssds => sssds.AddNewOrder(expectedOrder)).Returns(expectedOrder);
            mockSqlStoreSampleDataSource.Setup(sssds => sssds.SaveChanges()).ReturnsInOrder(true, false);
        }

        [TestInitialize]
        public void Initialize()
        {
            this.mockDataStore = mockSqlStoreSampleDataSource.Object;
            this.orderRepository = new SqlOrderRepository(this.mockDataStore);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_NullStoreSampleDataSource_NullReferenceException()
        {
            IOrderRepository orderRepository = new SqlOrderRepository(null);
        }

        [TestMethod]
        public void Constructor_ValidStoreSampleDataSource_SqlOrderRepositoryInstance()
        {
            IOrderRepository orderRepository = new SqlOrderRepository(this.mockDataStore);

            Assert.IsNotNull(orderRepository);
        }

        [TestMethod]
        public void GetAllBooks_ValidOrderRepository_AllOrdersReturned()
        {
            List<Order> actualOrders = this.orderRepository.GetAllOrders();

            Assert.IsNotNull(actualOrders);
            Assert.AreEqual(expectedOrders.Count, actualOrders.Count);
            Assert.AreEqual(expectedOrders[0].IdOrder, actualOrders[0].IdOrder);
        }

        [TestMethod]
        public void GetOrderById_NonExistantOrderIdProvided_NullOrderReturned()
        {
            Order actualOrder = this.orderRepository.GetOrderById(int.MaxValue);

            Assert.IsNull(actualOrder);
        }

        [TestMethod]
        public void GetOrderById_ValidIdProvided_ExpectedOrderReturned()
        {
            Order actualOrder = this.orderRepository.GetOrderById(0);

            Assert.IsNotNull(actualOrder);
            Assert.AreEqual(expectedOrders[0].IdOrder, actualOrder.IdOrder);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddOrder_NullOrderProvided_NullReferenceException()
        {
            Order actualOrder = this.orderRepository.AddOrder(null);
        }

        [TestMethod]
        public void AddOrder_OrderProvided_ExpectedOrderReturned()
        {
            Order actualOrder = this.orderRepository.AddOrder(expectedOrder);

            Assert.IsNotNull(actualOrder);
            Assert.AreEqual(expectedOrder.IdOrder, actualOrder.IdOrder);
        }

        [TestMethod]
        public void SaveChanges_Success()
        {
            bool result = this.orderRepository.SaveChanges();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SaveChanges_Failure()
        {
            bool result = this.orderRepository.SaveChanges();

            Assert.IsFalse(result);
        }
    }
}
