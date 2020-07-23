using Nadir.Core;
using System;

namespace Nadir.Storage
{
    class Depot : IDepot
    {
        public Depot(IPersistor persistor, IRetriever retriever)
        {
            Persistor = persistor;
            Retriever = retriever;
        }





        public T Load<T>(Guid guid)
            where T : Aggregate
        {
            return Retriever.Retrieve<T>(guid);
        }



        [Obsolete("This will be removed in future releases.")]
        public T Load<T, U>(U aggregateId)
            where T : Aggregate
            where U : AggregateId
        {
            throw new NotImplementedException();
        }



        public void Save<T>(T aggregate)
            where T : Aggregate
        {
            Persistor.Persist(aggregate);
        }





        private IPersistor Persistor;

        private IRetriever Retriever;
    }
}
