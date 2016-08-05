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
    public class AzureQueueManagerTests
    {
        private string storageConnectionSetting = "AzureStorageAccountConnection";
        private string targetQueueSetting = "TargetQueue";
      
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyConnectionStringSetting_ArgumentException()
        {
            string storageConnectionSetting = string.Empty;

            AzureQueueManager queueManager = new AzureQueueManager(storageConnectionSetting, this.targetQueueSetting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidConnectionStringSettingName_ArgumentException()
        {
            string storageConnectionSetting = "connection";

            AzureQueueManager queueManager = new AzureQueueManager(storageConnectionSetting, this.targetQueueSetting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyTargetQueueSettingName_ArgumentException()
        {
            string targetQueueSetting = string.Empty;

            AzureQueueManager queueManager = new AzureQueueManager(this.storageConnectionSetting, targetQueueSetting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidTargetQueueSettingName_ArgumentException()
        {
            string targetQueueSetting = "queue";

            AzureQueueManager queueManager = new AzureQueueManager(this.storageConnectionSetting, targetQueueSetting);
        }  
    }
}
