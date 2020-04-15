using Microsoft.Extensions.DependencyInjection;
using Nadir.Network;
using Nadir.Storage;
using System;

namespace Nadir.EventStore
{
    public static class AppExtension
    {
        public static void UseEventStore(this StorageBuilder builder, Func<IStorageEndpoint> initiate)
        {
            builder.Services.AddSingleton(initiate());



            builder.Services.AddScoped<IStorage, Storage>();
            builder.Services.AddScoped<IPersistor, Persistor>();
        }
    }
}
