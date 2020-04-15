using Nadir.Core;
using System;
using System.Linq;

namespace Nadir
{
    class Factory : IFactory
    {
        public T Create<T>(Guid guid)
            where T : Aggregate
        {
            var parameters = typeof(T).GetConstructors().Single().GetParameters().Select(p => (object)null).ToArray();
            var aggregate = (T)Activator.CreateInstance(typeof(T), parameters);
            aggregate.CreateAggregate(guid);

            return aggregate;
        }
    }
}
