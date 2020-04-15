using Nadir.Core;

namespace Nadir.Storage
{
    public interface IPersistor
    {
        void Persist<T>(T aggregate)
            where T : Aggregate;
    }
}
