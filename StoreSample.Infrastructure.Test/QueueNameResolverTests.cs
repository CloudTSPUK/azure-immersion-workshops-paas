namespace StoreSample.Infrastructure.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Azure.WebJobs;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class QueueNameResolverTests
    {
        static INameResolver queueNameResolver;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            queueNameResolver = new QueueNameResolver();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Resolve_EmptyNamePassed_ArgumentException()
        {
            string name = string.Empty;

            string queueName = queueNameResolver.Resolve(name);
        }

        [TestMethod]
        public void Resolve_ValidAppSettingNamePassed_QueueNameReturned()
        {
            string name = "targetQueue";
            string expectedQueueName = "orders";

            string queueName = queueNameResolver.Resolve(name);

            Assert.AreEqual(expectedQueueName, queueName);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            queueNameResolver = null;
        }
    }
}
