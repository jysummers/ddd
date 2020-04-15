using Nadir.Core;

namespace Nadir.Transit
{
    public interface IBus
    {
        void Dispatch<T>(T aggregate)
            where T : Aggregate;
    }
}
