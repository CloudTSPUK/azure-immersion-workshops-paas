namespace StoreSample.Infrastructure.Integration.Tests
{
    using Data;
    using Microsoft.Azure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    using System;

    [TestClass]
    public class AzureQueueManagerTests
    {
        private static CloudQueueClient queueClient;

        private string storageConnectionSetting = "AzureStorageAccountConnection";
        private string targetQueueSetting = "TargetQueue";

        private static string queueName;

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

        [TestMethod]
        public void Constructor_CorrectParameters_ValidQueueManagerCreated()
        {
            AzureQueueManager queueManager = new AzureQueueManager(this.storageConnectionSetting, this.targetQueueSetting);

            Assert.IsNotNull(queueManager);
        }

        [TestMethod]
        public void CreateQueue_ValidQueueCreation_AzureQueueCreatedAndRetrievedFromAzure()
        {
            string expectedQueueName = "orders";

            AzureQueueManager queueManager = new AzureQueueManager(this.storageConnectionSetting, this.targetQueueSetting);

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

            AzureQueueManager queueManager = new AzureQueueManager(this.storageConnectionSetting, this.targetQueueSetting);

            queueManager.CreateQueue();

            queueManager.EnqueueMessage(expectedOrder);

            CloudQueue actualQueue = queueClient.GetQueueReference(expectedQueueName);

            CloudQueueMessage actualMessage = actualQueue.GetMessage();

            Order actualOrder = JsonConvert.DeserializeObject<Order>(actualMessage.AsString);

            Assert.AreEqual(expectedOrder.IdOrder, actualOrder.IdOrder);
            Assert.AreEqual(expectedOrder.CreditCardNumber, actualOrder.CreditCardNumber);
            Assert.AreEqual(expectedOrder.PostCode, actualOrder.PostCode);
        }
    }
}
