using Nadir.Core;
using System;

namespace Nadir.Transit
{
    public interface IConsumer
    {
        void Consume<T>(Action<T> action)
            where T : Aggregate;
    }
}
