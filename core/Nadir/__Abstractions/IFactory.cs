using Nadir.Core;
using System;

namespace Nadir
{
    public interface IFactory
    {
        T Create<T>(Guid guid)
            where T : Aggregate;
    }
}
