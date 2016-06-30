using DbUp;
using System;
using System.Linq;
using System.Reflection;

namespace StoreSample.Build.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            // we want to override the configuration setting, in case we get passed an argument
            // which is what we will do in the build system
            var defaultConnectionString = args.FirstOrDefault() ?? System.Configuration.ConfigurationManager.AppSettings["connectionString"];

            var upgrader = DeployChanges.To
                    .SqlDatabase(defaultConnectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .WithTransactionPerScript()
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
