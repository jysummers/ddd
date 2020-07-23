using Nadir.Core;
using Nadir.Network;
using Nadir.Storage;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Nadir.EventStore
{
    class Retriever : IRetriever
    {
        public Retriever(IRetrieverEndpoint endpoint, IFactory factory)
        {
            Endpoint = endpoint as EventStoreEndpoint;
            Factory = factory;
        }





        public T Retrieve<T>(Guid guid) 
            where T : Aggregate
        {
            var aggregateId = new AggregateId(typeof(T), guid);

            var result = Endpoint.Connection.ReadStreamEventsForwardAsync(aggregateId.ToString(), 0, -1, false).GetAwaiter().GetResult();

            var aggregate = Factory.Create<T>(guid);

            foreach (var resEvent in result.Events)
            {
                var evt = resEvent.Event;

                var reconstructedEvent = ReconstructEvent(Encoding.UTF8.GetString(evt.Data), Encoding.UTF8.GetString(evt.Metadata));
                var metadata = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(evt.Metadata));
                //aggregate.Mutate();
                //Console.WriteLine(Encoding.UTF8.GetString(evt.Event.Data));

                throw new NotImplementedException();
            }

            return aggregate;
        }





        private object ReconstructEvent(string data, string metadata)
        {
            return null;
        }





        private EventStoreEndpoint Endpoint;

        private IFactory Factory;
    }
}
