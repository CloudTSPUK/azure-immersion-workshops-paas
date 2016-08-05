namespace StoreSample.Infrastructure
{
    using Interfaces;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    using System;

    public class AzureQueueManager : IQueueManager
    {
        private CloudStorageAccount cloudStorageAccount;
        private string targetQueueName;

        private CloudQueue azureQueue;

        public AzureQueueManager(string storageConnectionSetting, string targetQueueSetting)
        {
            Guard.NotNullOrEmpty(storageConnectionSetting, "The storage connection setting was null. Cannot identify which cloud storage account to use.");

            Guard.NotNullOrEmpty(targetQueueSetting, "The item to be added to the queue was null. Cannot add a null item to the queue.");

            this.targetQueueName = CloudConfigurationManager.GetSetting(targetQueueSetting);

            Guard.NotNullOrEmpty(this.targetQueueName, "Either the target queue setting does not exist in your cloud application.");

            string storageConnectionString = CloudConfigurationManager.GetSetting(storageConnectionSetting);

            if (!CloudStorageAccount.TryParse(storageConnectionString, out this.cloudStorageAccount))
            {
                throw new ArgumentException("Could not parse the Azure Storage Connection string. Unable to connect to Azure Storage.");
            }
        }

        public bool CreateQueue()
        {
            CloudQueueClient orderQueueClient = cloudStorageAccount.CreateCloudQueueClient();

            this.azureQueue = orderQueueClient.GetQueueReference(this.targetQueueName);

            return this.azureQueue.CreateIfNotExists();
        }

        public void EnqueueMessage<T>(T item)
        {
            Guard.NotNull(item, "The item to be added to the queue was null. Cannot add a null item to the queue.");

            string jsonSerialisedItem = JsonConvert.SerializeObject(item);

            CloudQueueMessage queueMessage = new CloudQueueMessage(jsonSerialisedItem);

            this.azureQueue.AddMessage(queueMessage);
        }
    }
}
