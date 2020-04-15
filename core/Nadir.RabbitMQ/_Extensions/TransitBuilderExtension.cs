using Microsoft.Extensions.DependencyInjection;
using Nadir.Network;
using Nadir.RabbitMQ;
using Nadir.Transit;
using System;

namespace Nadir
{
    public static class TransitBuilderExtension
    {
        public static void UseRabbitMQ(this TransitBuilder builder, Func<ITransitEndpoint> initiate)
        {
            builder.Services.AddSingleton(initiate());



            builder.Services.AddScoped<IBus, Bus>();
            builder.Services.AddScoped<IConsumer, Consumer>();
        }
    }
}
