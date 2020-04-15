using Microsoft.Extensions.DependencyInjection;
using Nadir.Network;
using Nadir.Storage;
using Nadir.Transit;
using System;

namespace Nadir
{
    public class AppBuilder
    {
        public AppBuilder(IServiceCollection services, Action<CoreBuilder> configure)
        {
            Services = services;
            Core = new CoreBuilder(Services);
            configure(Core);
        }





        internal AppBuilder PreBuild()
        {
            Services.AddSingleton(provider =>
            {
                var daemon = new Daemon();
                var consumer = provider.GetService<IConsumer>();
                var persistor = provider.GetService<IPersistor>();

                foreach (var jobs in Core.DaemonJobs)
                {
                    jobs(daemon, consumer, persistor);
                }

                return daemon;
            });

            return this;
        }



        public void Build(IServiceProvider provider)
        {
            {
                var endpoint = provider.GetService<ITransitEndpoint>();
                endpoint.Connect();
            }

            {
                var endpoint = provider.GetService<IStorageEndpoint>();
                endpoint.Connect();
            }

            provider.GetService<Daemon>().Start();
        }





        internal IServiceCollection Services { get; private set; }


        internal CoreBuilder Core { get; private set; }
    }
}
