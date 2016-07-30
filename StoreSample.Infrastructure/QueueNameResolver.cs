namespace StoreSample.Infrastructure
{
    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure;

    public class QueueNameResolver : INameResolver
    {
        public string Resolve(string name)
        {
            Guard.NotNullOrEmpty(name, "The provided queue name was null or empty. Unable to create a queue configuration.");

            return CloudConfigurationManager.GetSetting(name);  
        }
    }
}
