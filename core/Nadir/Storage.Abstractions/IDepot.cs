using Nadir.Core;
using System;

namespace Nadir.Storage
{
    public interface IDepot
    {
        T Load<T>(Guid guid)
            where T : Aggregate;

        [Obsolete("This will be removed in future releases.")]
        T Load<T, U>(U aggregateId)
            where T : Aggregate
            where U : AggregateId;

        void Save<T>(T aggregate)
            where T : Aggregate;
    }
}
