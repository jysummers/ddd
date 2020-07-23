using Microsoft.Extensions.DependencyInjection;
using Nadir.EventStore;
using Nadir.Network;
using Nadir.Storage;
using System;

namespace Nadir
{
    public static class StorageBuilderExtension
    {
        public static void UseEventStore(this PersistorBuilder builder, Func<IPersistorEndpoint> initiate)
        {
            builder.Services.AddSingleton(initiate());

            builder.Services.AddScoped<IPersistor, Persistor>();
        }



        public static void UseEventStore(this RetrieverBuilder builder, Func<IRetrieverEndpoint> initiate)
        {
            builder.Services.AddSingleton(initiate());

            builder.Services.AddScoped<IRetriever, Retriever>();
        }
    }
}
