namespace StoreSample.Infrastructure.Interfaces
{
    using System;

    public interface IQueueManager
    {
        bool CreateQueue();

        void DequeueMessage<T>(Func<T, T> messageOperation, Func<bool> messageDeletionValidator);

        void EnqueueMessage<T>(T item);
    }
}