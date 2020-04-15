using Nadir.Core;
using Nadir.Network;
using Nadir.Transit;
using RabbitMQ.Client.Framing;

namespace Nadir.RabbitMQ
{
    class Bus : IBus
    {
        public Bus(ITransitEndpoint endpoint)
        {
            Endpoint = endpoint as RabbitMQEndpoint;
        }





        public void Dispatch<T>(T aggregate)
            where T : Aggregate
        {
            using (var channel = Endpoint.Connection.CreateModel())
            {
                var queueName = aggregate.Id.Classification.FullName;
                var properties = CreateBasicProperties();
                var body = Aggregate.Pack(aggregate);

                channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.BasicPublish(exchange: string.Empty, routingKey: queueName, mandatory: false, basicProperties: properties, body: body);
            }
        }



        private BasicProperties CreateBasicProperties()
        {
            return new BasicProperties()
            {
                Persistent = true
            };
        }





        private readonly RabbitMQEndpoint Endpoint;
    }
}
