using Nadir.Core;
using System;

namespace Nadir.Storage
{
    public interface IRetriever
    {
        T Retrieve<T>(Guid guid)
            where T : Aggregate;
    }
}
