using Nadir.Core;
using Nadir.Network;
using RabbitMQ.Client;

namespace Nadir.RabbitMQ
{
    public class RabbitMQEndpoint : ITransitEndpoint
    {
        public RabbitMQEndpoint()
        {
            var factory = new ConnectionFactory();

            Connection = factory.CreateConnection();
        }



        public RabbitMQEndpoint(string username, string password, string hostname)
        {
            var factory = new ConnectionFactory()
            {
                UserName = username,
                Password = password,
                HostName = hostname
            };

            Connection = factory.CreateConnection();
        }





        public void Connect()
        {
            Channel = Connection.CreateModel();
        }



        public void Disconnect()
        {
            Channel.Close();
            Connection.Close();
        }





        public IConnection Connection { get; }

        public IModel Channel
        {
            get
            {
                return _Channel ?? throw new NotInitializedException("Make sure to call the Connect method first.");
            }

            private set
            {
                _Channel = value;
            }
        }
        private IModel _Channel;
    }
}
