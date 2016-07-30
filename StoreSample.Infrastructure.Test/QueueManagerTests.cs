namespace StoreSample.Infrastructure.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QueueManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyConnectionStringSetting_ArgumentException()
        {
            string storageConnectionSetting = string.Empty;
            string queueName = "queueName";

            QueueManager queueManager = new QueueManager(storageConnectionSetting, queueName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyQueueName_ArgumentException()
        {
            string storageConnectionSetting = "AzureWebJobsStorage";
            string queueName = string.Empty;

            QueueManager queueManager = new QueueManager(storageConnectionSetting, queueName);
        }
    }
}
