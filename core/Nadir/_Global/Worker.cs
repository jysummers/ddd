using Nadir.Core;
using Nadir.Storage;
using Nadir.Transit;

namespace Nadir
{
    public sealed class Worker<T> : Worker
        where T : Aggregate
    {
        public Worker(IConsumer consumption, IPersistor persistor)
        {
            Consumer = consumption;
            Persistor = persistor;
        }




        private void Persist(T aggregate)
        {
            Persistor.Persist(aggregate);
        }



        public override void Run()
        {
            Consumer.Consume<T>(Persist);
        }





        private IConsumer Consumer { get; }

        private IPersistor Persistor { get; }
    }
}
