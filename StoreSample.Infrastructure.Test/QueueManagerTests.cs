namespace StoreSample.Infrastructure.Test
{
    using Data;
    using Microsoft.Azure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class QueueManagerTests
    {
        private static CloudQueueClient queueClient;

        private string storageConnectionSetting = "AzureStorageAccountConnection";
        private string targetQueueSetting = "TargetQueue";
 
        private static string queueName;


        #region Test setup and tear down methods
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            queueName = CloudConfigurationManager.GetSetting("TargetQueue");

            string storageConnectionSetting = "AzureStorageAccountConnection";

            string storageConnectionString = CloudConfigurationManager.GetSetting(storageConnectionSetting);

            CloudStorageAccount cloudStorageAccount;
            CloudStorageAccount.TryParse(storageConnectionString, out cloudStorageAccount);

            queueClient = cloudStorageAccount.CreateCloudQueueClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            CloudQueue testQueue = queueClient.GetQueueReference(queueName);

            if (testQueue.Exists())
            {
                testQueue.Clear();
            }
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            CloudQueue testQueue = queueClient.GetQueueReference(queueName);

            bool success = testQueue.DeleteIfExists();

            queueClient = null;
        }
        #endregion


        #region Queue Manager Unit Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyConnectionStringSetting_ArgumentException()
        {
            string storageConnectionSetting = string.Empty;

            QueueManager queueManager = new QueueManager(storageConnectionSetting, this.targetQueueSetting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidConnectionStringSettingName_ArgumentException()
        {
            string storageConnectionSetting = "connection";

            QueueManager queueManager = new QueueManager(storageConnectionSetting, this.targetQueueSetting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyTargetQueueSettingName_ArgumentException()
        {
            string targetQueueSetting = string.Empty;

            QueueManager queueManager = new QueueManager(this.storageConnectionSetting, targetQueueSetting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidTargetQueueSettingName_ArgumentException()
        {
            string targetQueueSetting = "queue";

            QueueManager queueManager = new QueueManager(this.storageConnectionSetting, targetQueueSetting);
        }

        #endregion


        #region Queue Manager Azure Integration Tests
        /// <summary>
        /// This region contains tests that validate the configuration and use of the QueueManager with Azure storage queues.
        /// Where the QueueManager is configured to use testing values taken from the test projects app.config file.
        /// 
        /// These are integration tests that have dependancies on external Azure SDK API's. These tests can be used to validate
        /// that the overall functionality of the QueueManager works as expected with Azure. The QueueManagers CreateQueue
        /// and EnqueueMessage methods modify external state as opposed to return observable values.
        /// </summary>

        [TestMethod]
        public void Constructor_CorrectParameters_ValidQueueManagerCreated()
        {
            QueueManager queueManager = new QueueManager(this.storageConnectionSetting, this.targetQueueSetting);

            Assert.IsNotNull(queueManager);
        }

        [TestMethod]
        public void CreateQueue_ValidQueueCreation_AzureQueueCreatedAndRetrievedFromAzure()
        {
            string expectedQueueName = "orders";

            QueueManager queueManager = new QueueManager(this.storageConnectionSetting, this.targetQueueSetting);

            bool success = queueManager.CreateQueue();

            CloudQueue actualQueue = queueClient.GetQueueReference(expectedQueueName);

            Assert.IsTrue(success);
            Assert.IsNotNull(actualQueue);
            Assert.AreEqual(expectedQueueName, actualQueue.Name);
        }

        [TestMethod]
        public void EnqueueMessage_ValidOrder_MessageAddedToQueue()
        {
            string expectedQueueName = "orders";

            Order expectedOrder = new Order()
            {
                Book = new Book()
                {
                    Author = "Luke Devonshire",
                    Title = "Book Test",
                    Description = "Lorem Ipsum",
                    IdBook = 0,
                    Price = 1.00M
                },
                BookId = 0,
                CreditCardNumber = "123",
                Email = "a@a.com",
                FirstName = "Luke",
                LastName = "Devonshire",
                HouseNumber = "1",
                IdOrder = 0,
                OrderPlacedAtUtc = new DateTime(1900, 1, 1, 1, 1, 1),
                PostCode = "ABC DEF",
                Quantity = 1,
                TelephoneNumber = "00000000000",
                TotalPrice = 1
            };

            QueueManager queueManager = new QueueManager(this.storageConnectionSetting, this.targetQueueSetting);

            queueManager.CreateQueue();

            queueManager.EnqueueMessage(expectedOrder);

            CloudQueue actualQueue = queueClient.GetQueueReference(expectedQueueName);

            CloudQueueMessage actualMessage = actualQueue.GetMessage();

            Order actualOrder = JsonConvert.DeserializeObject<Order>(actualMessage.AsString);

            Assert.AreEqual(expectedOrder.IdOrder, actualOrder.IdOrder);
            Assert.AreEqual(expectedOrder.CreditCardNumber, actualOrder.CreditCardNumber);
            Assert.AreEqual(expectedOrder.PostCode, actualOrder.PostCode);
        }

        #endregion    
    }
}
