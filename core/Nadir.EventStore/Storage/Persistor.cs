using EventStore.ClientAPI;
using Nadir.Core;
using Nadir.Network;
using Nadir.Storage;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Nadir.EventStore
{
    class Persistor : IPersistor
    {
        public Persistor(IPersistorEndpoint endpoint)
        {
            Endpoint = endpoint as EventStoreEndpoint;
        }





        public void Persist<T>(T aggregate)
            where T : Aggregate
        {
            var streamName = aggregate.Id.ToString();

            foreach (var change in aggregate.Changes)
            {
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(change));
                var metadata = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { EventType = change.GetType().AssemblyQualifiedName }));
                var evt = new EventData(Guid.NewGuid(), change.GetType().FullName, true, data, metadata);

                Endpoint.Connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, evt).Wait();
            }
        }





        private EventStoreEndpoint Endpoint;
    }
}
