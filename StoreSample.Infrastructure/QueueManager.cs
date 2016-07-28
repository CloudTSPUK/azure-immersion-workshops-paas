namespace StoreSample.Infrastructure
{
    using Interfaces;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Newtonsoft.Json;
    using System;

    public class QueueManager : IQueueManager
    {
        private CloudStorageAccount cloudStorageAccount;
        private string queueName;

        private CloudQueue queue;

        public QueueManager(string storageConnectionSetting, string queueName)
        {
            Guard.NotNull(storageConnectionSetting, "The storage connection setting was null. Cannot identify which cloud storage account to use.");

            Guard.NotNull(queueName, "The item to be added to the queue was null. Cannot add a null item to the queue.");

            this.queueName = queueName;
       
            if (!CloudStorageAccount.TryParse(CloudConfigurationManager.GetSetting(storageConnectionSetting), out this.cloudStorageAccount))
            {
                throw new ArgumentException("Could not parse the Azure Storage Connection string. Unable to connect to Azure Storage.");
            }
        }

        public bool CreateQueue()
        {
            CloudQueueClient orderQueueClient = cloudStorageAccount.CreateCloudQueueClient();

            this.queue = orderQueueClient.GetQueueReference(this.queueName);

            return this.queue.CreateIfNotExists();
        }

        public void EnqueueMessage<T>(T item)
        {
            Guard.NotNull(item, "The item to be added to the queue was null. Cannot add a null item to the queue.");

            string jsonSerialisedItem = JsonConvert.SerializeObject(item);

            CloudQueueMessage queueMessage = new CloudQueueMessage(jsonSerialisedItem);

            this.queue.AddMessage(queueMessage);
        }

        public void DequeueMessage<T>(Func<T,T> messageOperation, Func<bool> messageDeletionValidator)
        {
            Guard.NotNull(messageOperation, "The message operation function was null. Cannot process the queue message.");
            Guard.NotNull(messageDeletionValidator, "The message deletion validator function was null. Cannot delete the queue message.");

            CloudQueueMessage queueMessage = this.queue.GetMessage();

            T queueMessageObject = JsonConvert.DeserializeObject<T>(queueMessage.AsString);

            messageOperation(queueMessageObject);

            if (messageDeletionValidator())
            {
                this.queue.DeleteMessage(queueMessage);
            }
        }
    }
}
