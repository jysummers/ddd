using Nadir.Core;

namespace MuzicStore.Domain.Albums
{
    public class Album : Aggregate
    {
        public Album(AggregateId id, string name, string title)
            : base(id)
        {
            Name = name;
            Title = title;
        }





        public void UpdateName(string name)
        {
            if (!string.IsNullOrWhiteSpace(Name))
                throw new InvalidMutationException("Name is already set.");

            Raise(new NameUpdated(name: name), OnNameCreated);
        }



        public void UpdateTitle(string title)
        {
            Raise(new TitleUpdated(title: title), OnTitleUpdated);
        }





        private void OnNameCreated(NameUpdated affair)
        {
            Name = affair.Name;
        }



        private void OnTitleUpdated(TitleUpdated affair)
        {
            Title = affair.Title;
        }





        public string Name { get; private set; }

        public string Title { get; private set; }
    }
}
