using Microsoft.Extensions.DependencyInjection;
using Nadir.EventStore;
using Nadir.Network;
using Nadir.Storage;
using System;

namespace Nadir
{
    public static class StorageBuilderExtension
    {
        public static void UseEventStore(this StorageBuilder builder, Func<IStorageEndpoint> initiate)
        {
            builder.Services.AddSingleton(initiate());



            builder.Services.AddScoped<IDepot, Depot>();
            builder.Services.AddScoped<IPersistor, Persistor>();
        }
    }
}
