namespace StoreSample.Infrastructure.Interfaces
{
    using System;

    public interface IQueueManager
    {
        bool CreateQueue();

        void EnqueueMessage<T>(T item);
    }
}