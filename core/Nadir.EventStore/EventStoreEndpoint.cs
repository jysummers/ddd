using EventStore.ClientAPI;
using Nadir.Network;
using System;

namespace Nadir.EventStore
{
    public class EventStoreEndpoint : IStorageEndpoint
    {
        public EventStoreEndpoint()
        {
            var uri = new Uri("tcp://admin:changeit@localhost:1113");
            Connection = EventStoreConnection.Create(uri);
        }



        public EventStoreEndpoint(string username, string password, string hostname, int port)
        {
            var uri = new Uri($"tcp://{username}:{password}@{hostname}:{port}");
            Connection = EventStoreConnection.Create(uri);
        }





        public void Connect()
        {
            Connection.ConnectAsync().Wait();
        }



        public void Disconnect()
        {
            Connection.Close();
        }





        public IEventStoreConnection Connection { get; }
    }
}
