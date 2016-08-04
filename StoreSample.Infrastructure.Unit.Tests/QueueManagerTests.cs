namespace StoreSample.Infrastructure.Unit.Tests
{
    using Microsoft.Azure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class QueueManagerTests
    {
        private string storageConnectionSetting = "AzureStorageAccountConnection";
        private string targetQueueSetting = "TargetQueue";
      
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
    }
}
