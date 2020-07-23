using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nadir;
using Nadir.EventStore;
using Nadir.Network;
using Nadir.RabbitMQ;

namespace MuzicStore.Tester
{
    [TestClass]
    public class Initializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var endpoints = CreateNewEndpoints();

            var services = new ServiceCollection();

            var app = services.ConfigureCore(builder =>
            {
                var endpoints = CreateNewEndpoints();

                builder.ConfigureCore();
                builder.ConfigureTransit(transit => transit.UseRabbitMQ(() => endpoints.TransitEndpoint));
                builder.ConfigurePersistor(persistor => persistor.UseEventStore(() => endpoints.PersistorEndpoint));
                builder.ConfigureRetriever(retriever => retriever.UseEventStore(() => endpoints.RetrieverEndpoint));

                builder.ConfigureMuzicStore();
            });



            Provider = services.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                //ValidateScopes = true
            });



            app.Build(Provider);
        }



        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Provider.Dispose();
        }



        private static Endpoints CreateNewEndpoints()
        {
            var transitEndpoint = new RabbitMQEndpoint(username: "admin", password: "admin", hostname: "localhost");
            var persistorEndpoint = new EventStoreEndpoint(username: "admin", password: "changeit", hostname: "localhost", port: 1113);
            var retrieverEndpoint = new EventStoreEndpoint(username: "admin", password: "changeit", hostname: "localhost", port: 1113);

            return new Endpoints(transitEndpoint, persistorEndpoint, retrieverEndpoint);
        }





        internal static ServiceProvider Provider { get; private set; }
    }
}
