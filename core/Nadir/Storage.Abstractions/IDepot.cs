using Nadir.Core;
using System;

namespace Nadir.Storage
{
    public interface IDepot
    {
        T Load<T>(Guid guid)
            where T : Aggregate;

        T Load<T, U>(U aggregateId)
            where T : Aggregate
            where U : AggregateId;

        void Save<T>(T aggregate)
            where T : Aggregate;
    }
}
