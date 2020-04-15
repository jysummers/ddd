using Nadir.Core;
using Nadir.Storage;

namespace Nadir.EventStore
{
    class Persistor : IPersistor
    {
        public Persistor(IStorage storage)
        {
            Storage = storage;
        }





        public void Persist<T>(T aggregate)
            where T : Aggregate
        {
            Storage.Save(aggregate);
        }





        IStorage Storage;
    }
}
