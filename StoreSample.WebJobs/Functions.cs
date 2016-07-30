namespace StoreSample.WebJobs
{
    using Data;
    using Data.Interfaces;
    using Infrastructure;
    using Microsoft.Azure.WebJobs;
    using System.IO;

    public class Functions
    {
        private static IOrderRepository _orderRepository;

        public Functions(IOrderRepository orderRepository)
        {
            Guard.NotNull(orderRepository, "The order repository passed to the web job was null. Unable to handle orders.");
           
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// This function will get triggered/executed when a new message is written on an Azure Queue called queue.
        /// 
        /// The use of the QueueTrigger here automates the dequeueing, deserialisation, error handling associated with working with a queue. Find more details here
        /// https://azure.microsoft.com/en-us/documentation/articles/websites-dotnet-webjobs-sdk-storage-queues-how-to/
        /// </summary>
        /// <param name="newOrder">A new order object that has been submitted to the order queue. Where the order queue is specified in the application settings.</param>
        /// <param name="log">Logging mechanism for the queue processing function.</param>
        public static void ProcessQueueMessage([QueueTrigger("%targetQueue%")] Order newOrder, TextWriter log)
        {
            Guard.NotNull(newOrder, "The order retrieved from the queue was null. Unable to process the order.");

            _orderRepository.AddOrder(newOrder);

            _orderRepository.SaveChanges();
        }
    }
}
