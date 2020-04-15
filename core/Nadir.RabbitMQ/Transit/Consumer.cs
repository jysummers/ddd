using Nadir.Core;
using Nadir.Network;
using Nadir.Transit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace Nadir.RabbitMQ
{
    class Consumer : IConsumer
    {
        public Consumer(ITransitEndpoint endpoint)
        {
            Endpoint = endpoint as RabbitMQEndpoint;
        }





        public void Consume<T>(Action<T> persist)
            where T : Aggregate
        {
            var channel = Endpoint.Channel;

            var queueName = CreateQueueName<T>();
            var consumer = CreateBasicConsumer(channel, persist);

            channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicConsume(consumer: consumer, queue: queueName, autoAck: false);
        }



        private string CreateQueueName<T>()
            where T : Aggregate
        {
            return typeof(T).FullName;
        }



        private IBasicConsumer CreateBasicConsumer<T>(IModel channel, Action<T> persist)
            where T : Aggregate
        {
            var consumer = new EventingBasicConsumer(Endpoint.Channel);
            consumer.Received += (ch, argument) =>
            {
                var aggregate = Aggregate.Unpack<T>(argument.Body);

                persist(aggregate);

                channel.BasicAck(argument.DeliveryTag, false);
            };

            return consumer;
        }





        private readonly RabbitMQEndpoint Endpoint;
    }
}
