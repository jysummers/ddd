using Microsoft.Extensions.DependencyInjection;
using Nadir.Network;
using Nadir.Storage;
using Nadir.Transit;
using System;
using System.Collections.Generic;

namespace Nadir
{
    public class CoreBuilder
    {
        public CoreBuilder(IServiceCollection services)
        {
            Services = services;
        }





        public void ConfigureCore()
        {
            Services.AddSingleton<Endpoints>();

            Services.AddScoped<IFactory, Factory>();
        }



        public void ConfigureTransit(Action<TransitBuilder> configure)
        {
            configure(new TransitBuilder(Services));
        }



        public void ConfigureStorage(Action<StorageBuilder> configure)
        {
            configure(new StorageBuilder(Services));
        }






        public void OnDaemonCreated(Action<Daemon, IConsumer, IPersistor> code)
        {
            DaemonJobs.Add(code);
        }





        internal IList<Action<Daemon, IConsumer, IPersistor>> DaemonJobs = new List<Action<Daemon, IConsumer, IPersistor>>();

        public IServiceCollection Services { get; private set; }
    }
}
