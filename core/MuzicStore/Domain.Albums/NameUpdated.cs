using Nadir.Core;

namespace MuzicStore.Domain.Albums
{
    public class NameUpdated : Affair
    {
        public NameUpdated(string name)
        {
            Name = name;
        }



        public string Name { get; }
    }
}
