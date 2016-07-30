namespace StoreSample.WebJobs
{
    using Infrastructure;
    using Microsoft.Azure;
    using Microsoft.Azure.WebJobs;

    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    public class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            JobHostConfiguration jobConfiguration = new JobHostConfiguration();

            jobConfiguration.DashboardConnectionString = CloudConfigurationManager.GetSetting("AzureWebJobsDashboard");
            jobConfiguration.StorageConnectionString = CloudConfigurationManager.GetSetting("AzureWebJobsStorage");
       
            jobConfiguration.NameResolver = new QueueNameResolver();

            JobHost host = new JobHost(jobConfiguration);

            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
