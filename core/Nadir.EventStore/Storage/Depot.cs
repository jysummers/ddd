using EventStore.ClientAPI;
using Nadir.Core;
using Nadir.Network;
using Nadir.Storage;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Nadir.EventStore
{
    class Depot : IDepot
    {
        public Depot(IStorageEndpoint endpoint)
        {
            Endpoint = endpoint as EventStoreEndpoint;
        }





        public T Load<T>(Guid guid)
            where T : Aggregate
        {
            throw new NotImplementedException();
        }



        public T Load<T, U>(U aggregateId)
            where T : Aggregate
            where U : AggregateId
        {
            //var streamEvents = conn.ReadStreamEventsForwardAsync("test-stream", 0, 1, false).Result;
            //var returnedEvent = streamEvents.Events[0].Event;

            //Console.WriteLine("Read event with data: {0}, metadata: {1}",
            //    Encoding.UTF8.GetString(returnedEvent.Data),
            //    Encoding.UTF8.GetString(returnedEvent.Metadata));



            throw new NotImplementedException();
        }



        public void Save<T>(T aggregate)
            where T : Aggregate
        {
            var streamName = aggregate.Id.ToString();

            foreach(var change in aggregate.Changes)
            {
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(change));
                var metadata = Encoding.UTF8.GetBytes("{}");
                var evt = new EventData(Guid.NewGuid(), change.GetType().FullName, true, data, metadata);

                Endpoint.Connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, evt).Wait();
            }
        }





        private EventStoreEndpoint Endpoint;
    }
}
