using Nadir.Core;

namespace MuzicStore.Domain.Albums
{
    public class TitleUpdated : Affair
    {
        public TitleUpdated(string title)
        {
            Title = title;
        }



        public string Title { get; }
    }
}
